using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    /// <summary>
    /// Interface of category repository - it is an abstract intermediate layer between the database and the controllers
    /// </summary>
    public interface ICategoryRepository : IRepository
    {
        void AddCategory(Category category);
        Task<Category> RemoveCategory(string category);
        Task<List<Category>> AllCategories();
        Task<Category> FindCategory(string categoryName);
        Task<List<Movie>> FindMoviesFromCategory(string Category);
        Task<int> CategoriesCount();
        Task<List<Category>> PaginatedCategories(int page, int itemsPerPage);
    }
}
