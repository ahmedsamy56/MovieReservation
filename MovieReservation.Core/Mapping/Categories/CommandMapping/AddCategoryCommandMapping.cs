using MovieReservation.Core.Features.Categories.Commands.Models;
using MovieReservation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.Core.Mapping.Categories
{
    public partial class CategoryProfile
    {
        public void AddCategoryCommandMapping()
        {
            CreateMap<AddCategoryCommand, Category>();
        }
    }
}
