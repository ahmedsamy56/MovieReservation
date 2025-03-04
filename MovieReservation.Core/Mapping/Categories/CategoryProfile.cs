using AutoMapper;

namespace MovieReservation.Core.Mapping.Categories
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            GetStudentListMapping();
            GetCategoryByIdMapping();
            AddCategoryCommandMapping();
            EditCategoryMapping();
        }
    }
}
