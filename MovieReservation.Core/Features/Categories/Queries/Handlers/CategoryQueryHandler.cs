using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Categories.Queries.Models;
using MovieReservation.Core.Features.Categories.Queries.Results;
using MovieReservation.Service.Abstracts;


namespace MovieReservation.Core.Features.Categories.Queries.Handlers
{
    public class CategoryQueryHandler :ResponseHandler, IRequestHandler<GetCategoryListQuery, Response<List<GetCategoryListResponse>>> ,
                                                         IRequestHandler<GetCategoryByIdQuery , Response<GetCategoryByIdResponse>>
     
                                                     
    {

        #region Fields
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public CategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        #endregion


        #region Functions
        public async Task<Response<List<GetCategoryListResponse>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var CategoryList = await _categoryService.GetCategoriesAsync();
            var CategoryListMapper = _mapper.Map<List<GetCategoryListResponse>>(CategoryList);
            return Success(CategoryListMapper);
        }

        public async Task<Response<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            //Get data 
            var category = await _categoryService.GetCategoryByIdWithIncludeAsync(request.id);
            //if not Exist 
            if (category == null)
                return NotFound<GetCategoryByIdResponse>();

            //mapping 
            var categoryMapping = _mapper.Map<GetCategoryByIdResponse>(category);

            //return
            return Success(categoryMapping);
        }


        #endregion

    }
}
