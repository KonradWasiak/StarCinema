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
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Category RemoveCategory(int categoryId);
        IList<Category> AllCategories(string orderBy = "");
        Category FindCategory(int categoryId);
        IList<Movie> FindMoviesFromCategory(int categoryId);
        int CategoriesCount();
        IList<Category> PaginatedCategories(int page, int itemsPerPage, string orderBy);
    }
}
