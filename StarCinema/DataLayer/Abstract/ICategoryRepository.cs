using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Task<Category> RemoveCategory(string category);
        Task<IEnumerable<Category>> AllCategories();
        Task<Category> FindCategory(string categoryName);
        Task<IEnumerable<Movie>> FindMoviesFromCategory(string Category);

    }
}
