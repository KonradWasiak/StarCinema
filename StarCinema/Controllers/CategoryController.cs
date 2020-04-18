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
        public IActionResult Categories([FromQuery] CategoryListingRequest request)
        {
            var categories = _categoryRepo.PaginatedCategories(request.Page, request.PageSize, request.OrderBy).ToList();
            var allCategoriesCount =  _categoryRepo.CategoriesCount();
            var categoriesViewModelList = new List<CategoryViewModel>();
            
            categories.ForEach(x => categoriesViewModelList.Add(new CategoryViewModel(x)));

            var categoriesViewModel = new ListingViewModel<CategoryViewModel>(categoriesViewModelList, request.Page, allCategoriesCount, request.OrderBy);

            return View(categoriesViewModel);
        }

        [HttpPost]
        public IActionResult RemoveCategory(int categoryId)
        {
            var removedCategory = _categoryRepo.RemoveCategory(categoryId);
            return RedirectToAction("Categories");
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
                return RedirectToAction("Categories");
            }
            return View(category);
        }

        private  IList<CategoryViewModel> getAllCategories()
        {
            var allCategories = _categoryRepo.AllCategories().ToList();
            var categoriesViewModel = new List<CategoryViewModel>();
            allCategories.ForEach(x => categoriesViewModel.Add(new CategoryViewModel(x)));
            return categoriesViewModel;
        }

    }
}