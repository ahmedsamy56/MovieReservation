
using MovieReservation.Core.Features.Categories.Queries.Results;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Categories
{
    public partial class CategoryProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Category, GetCategoryListResponse>();
        }
    }
}
