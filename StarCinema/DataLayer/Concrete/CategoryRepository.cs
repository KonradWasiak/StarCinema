using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StarCinemaContext context;

        public CategoryRepository(StarCinemaContext context)
        {
            this.context = context;
        }
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
        public IList<Category> AllCategories(string orderBy = "")
        {
            switch (orderBy)
            {
                case "NameAsc":
                    return context.Categories.Include(m => m.Movies)
                        .OrderBy(x => x.CategoryName)
                        .ToList();
                case "NameDesc":
                    return context.Categories.Include(m => m.Movies)
                        .OrderByDescending(x => x.CategoryName)
                        .ToList();
                default:
                    return context.Categories.Include(m => m.Movies)
                        .OrderBy(x => x.CategoryName)
                        .ToList();
            }
        }

        public int CategoriesCount()
        {
            return this.context.Categories.Count();
        }

        public Category FindCategory(int categoryId)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category;
        }
        public IList<Movie> FindMoviesFromCategory(int categoryId)
        {
            return context.Movies.Include(m => m.Comments)
                .Include(m => m.Rates)
                .Include(m => m.Shows)
                .Where(m => m.Category.Id == categoryId)
                .ToList();
        }

        public IList<Category> PaginatedCategories(int page, int itemsPerPage, string orderBy)
        {
            var sortedCategories = AllCategories(orderBy);
            return sortedCategories.Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }

        public Category RemoveCategory(int categoryId)
        {
            var categoryToRemove = FindCategory(categoryId);
            if (categoryToRemove != null)
                context.Categories.Remove(categoryToRemove);

            context.SaveChanges();

            return categoryToRemove;
        }
    }
}
