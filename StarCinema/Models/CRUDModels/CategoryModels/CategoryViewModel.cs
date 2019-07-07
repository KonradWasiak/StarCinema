using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
        public CategoryViewModel(Category category)
        {
            this.Name = category.CategoryName;
        }
        public CategoryViewModel() { }


    }
}
