using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CategoryModels
{
    public class CategoryFactory
    {
        public Category GetCategory(CategoryViewModel category)
        {
            return new Category()
            {
                CategoryName = category.Name,
            };
        }
    }
}
