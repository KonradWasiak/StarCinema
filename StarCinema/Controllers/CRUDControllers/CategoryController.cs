using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class CategoryController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(IMovieRepository movieRepo, ICategoryRepository categoryRepo)
        {
            this._movieRepo = movieRepo; 
            this._categoryRepo = categoryRepo; 

        }
        public async Task<IActionResult> Categories(int id)
        {
            var allCategories = await this._categoryRepo.PaginatedCategories(id, 2);
            var categoriesViewModelList = new List<CategoryViewModel>();

            foreach (var c in allCategories)
            {
                categoriesViewModelList.Add(new CategoryViewModel(c));
            }

            int categoriesCount = await _categoryRepo.CategoriesCount();
            int totalPages = categoriesCount % 2 > 0 ? categoriesCount / 2 + 1 : categoriesCount / 2;

            var categoriesViewModel = new PaginatedCategoriesViewModel(categoriesViewModelList, new PagingInfo
            {
                ItemsPerPage = 2,
                CurrentPage = id,
                TotalPages = totalPages
            });;
            return View(categoriesViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveCategory(string categoryName)
        {
            await this._categoryRepo.RemoveCategory(categoryName);
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
                this._categoryRepo
                    .AddCategory(new Category()
                {
                    CategoryName = category.Name
                });
                return View();
            }
            return View(category);
        }

        public async Task<IActionResult> SortCategoriesByNameAsc()
        {
            var categoriesViewModel = await getAllCategories();
            return View("Categories", categoriesViewModel.OrderBy(c => c.Name));
        }

        public async Task<IActionResult> SortCategoriesByNameDesc()
        {
            var categoriesViewModel = await getAllCategories();
            return View("Categories", categoriesViewModel.OrderByDescending(c => c.Name));
        }

        private async Task<List<CategoryViewModel>> getAllCategories()
        {
            var allCategories = await this._categoryRepo.AllCategories();
            var categoriesViewModel = new List<CategoryViewModel>();
            foreach (var c in allCategories)
            {
                categoriesViewModel.Add(new CategoryViewModel(c));
            }
            return categoriesViewModel;
        }

    }
}