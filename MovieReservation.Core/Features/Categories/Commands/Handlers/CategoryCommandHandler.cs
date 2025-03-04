using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Categories.Commands.Models;
using MovieReservation.Data.Entities;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Categories.Commands.Handlers
{
    public class CategoryCommandHandler : ResponseHandler,
                                          IRequestHandler<AddCategoryCommand, Response<string>>,
                                          IRequestHandler<EditCategoryCommand, Response<string>>,
                                          IRequestHandler<DeleteCategoryCommand, Response<string>>
    {
        #region Fields
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public CategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        #endregion

        #region Functions
        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            //mapping
            var CategoryMapping = _mapper.Map<Category>(request);
            //create
            var result = await _categoryService.AddAsync(CategoryMapping);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            //if Not Exist 
            var category = await _categoryService.CategoryExistAsync(request.Id);

            //Return NotFound
            if (!category) return NotFound<string>("Category NotFound");

            //Mapping 
            var CategoryMapping = _mapper.Map<Category>(request);

            //Edit 
            var result = await _categoryService.EditCategoryAsync(CategoryMapping);

            //Return
            if (result == "Success") return Created($"Category Id = {CategoryMapping.Id}", "Edit Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            //if Not Exist 
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            //Return NotFound
            if (category == null) return NotFound<string>("Category NotFound");
            //Delete 
            var result = await _categoryService.DeleteCategoryAsync(category);
            //Return
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }

        #endregion

    }
}
