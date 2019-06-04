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
        public async Task<IEnumerable<Category>> AllCategories()
        {
            IEnumerable<Category> allCategories = await context.Categories.Include(m => m.Movies).ToListAsync();
            return allCategories;
        }

        public async Task<int> CategoriesCount()
        {
            return await this.context.Categories.CountAsync();
        }

        public async Task<Category> FindCategory(string categoryName)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            return category;
        }
        public async Task<IEnumerable<Movie>> FindMoviesFromCategory(string category)
        {
            var cat = await FindCategory(category);
            IEnumerable<Movie> moviesToReturn = await context.Movies.Include(m => m.Comments)
                                                               .Include(m => m.Rates)
                                                               .Include(m => m.Shows)
                                                               .Where(m => m.Category.CategoryName == category)
                                                               .ToListAsync();
            return moviesToReturn;
        }

        public async Task<IEnumerable<Category>> PaginatedCategories(int page, int itemsPerPage)
        {
            return await this.context.Categories.Include(c => c.Movies)
                                                .Skip((page - 1) * itemsPerPage)
                                                .Take(itemsPerPage)
                                                .ToListAsync();
                                                
        }

        public async Task<Category> RemoveCategory(string category)
        {
            var categoryToRemove = await FindCategory(category);
            if (categoryToRemove != null)
                context.Categories.Remove(categoryToRemove);

            await context.SaveChangesAsync();

            return categoryToRemove;
        }
    }
}
