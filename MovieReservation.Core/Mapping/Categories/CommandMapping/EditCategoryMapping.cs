using MovieReservation.Core.Features.Categories.Commands.Models;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Categories
{
    public partial class CategoryProfile
    {
        public void EditCategoryMapping()
        {
            CreateMap<EditCategoryCommand, Category>();
        }
    }
}
