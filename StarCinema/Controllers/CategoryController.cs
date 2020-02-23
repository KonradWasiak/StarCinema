using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;
using StarCinema.Models.CRUDModels.CategoryModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class CategoryController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly CategoryFactory _categoryFactory;
        private readonly IConfiguration _config;
        private int _itemsPerPage;

        public CategoryController(IMovieRepository movieRepo, ICategoryRepository categoryRepo, CategoryFactory categoryFactory, IConfiguration configuration)
        {
            this._movieRepo = movieRepo; 
            this._categoryRepo = categoryRepo;
            this._categoryFactory = categoryFactory;
            this._config = configuration;
            this._itemsPerPage = _config.GetValue<int>("ItemsPerPage");

        }
        public async Task<IActionResult> Categories(int id)
        {
            var categories = await _categoryRepo.PaginatedCategories(id, _itemsPerPage);
            var allCategoriesCount = await _categoryRepo.CategoriesCount();
            var categoriesViewModelList = new List<CategoryViewModel>();
            
            categories.ForEach(x => categoriesViewModelList.Add(new CategoryViewModel(x)));

            var categoriesViewModel = new PaginatedViewModel<CategoryViewModel>(categoriesViewModelList, id, allCategoriesCount);

            return View(categoriesViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveCategory(string categoryName)
        {
            var removedCategory = await _categoryRepo.RemoveCategory(categoryName);
            return View(removedCategory.CategoryName);
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
                var categoryToAdd = _categoryFactory.GetCategory(category);
                _categoryRepo.AddCategory(categoryToAdd);
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
            var allCategories = await _categoryRepo.AllCategories();
            var categoriesViewModel = new List<CategoryViewModel>();
            allCategories.ForEach(x => categoriesViewModel.Add(new CategoryViewModel(x)));
            return categoriesViewModel;
        }

    }
}