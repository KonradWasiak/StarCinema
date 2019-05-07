using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class CategoryController : Controller
    {
        private readonly IMovieRepository _repo;

        public CategoryController(IMovieRepository repo)
        {
            this._repo = repo; 
        }
        public async Task<IActionResult> Categories()
        {
            var allCategories = await this._repo.AllCategories();
            List<CategoryViewModel> categoriesViewModel = new List<CategoryViewModel>(); 
            foreach (var c in allCategories)
            {
                categoriesViewModel.Add(new CategoryViewModel(c));
            }
            return View(categoriesViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveCategory(string categoryName)
        {
            await this._repo.RemoveCategory(categoryName);
            return View((object)categoryName);
        }


        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                this._repo.AddCategory(new Category()
                {
                    CategoryName = category.Name
                });
                return View();
            }
            return View(category);
        }

    }
}