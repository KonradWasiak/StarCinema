using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.CommentModels;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class AddEditMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Directory { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int DurationTime { get; set; }
        public string TrailerUrl { get; set; }
        public bool Is3D { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<SelectListItem> Categories{ get; set; }
        public AddEditMovieRequest Request { get; set; }

        public AddEditMovieViewModel(List<Category> categories, Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Directory = movie.Directory;
            Description = movie.Description;
            Category = movie.Category.Id.ToString();
            DurationTime = movie.DurationTime;
            TrailerUrl = movie.TrailerUrl;
            Is3D = movie.Is3D;
            ReleaseDate = movie.ReleaseDate;
            Request = new AddEditMovieRequest();
            Categories = new List<SelectListItem>();
            categories.ForEach(c => Categories.Add(CreateCategorySelectListItem(c)));
        }
        public AddEditMovieViewModel(List<Category> categories, AddEditMovieRequest request)
        {
            Id = request.Id;
            Title = request.Title;
            Directory = request.Directory;
            Description = request.Description;
            Category = categories.Where(x => x.Id == request.CategoryId).FirstOrDefault().CategoryName;
            DurationTime = request.DurationTime;
            TrailerUrl = request.TrailerUrl;
            Is3D = request.Is3D;
            ReleaseDate = request.ReleaseDate;

            Categories = new List<SelectListItem>();
            categories.ForEach(c => Categories.Add(CreateCategorySelectListItem(c)));
        }
        public AddEditMovieViewModel(List<Category> categories)
        {
            Categories = new List<SelectListItem>();
            categories.ForEach(c => Categories.Add(CreateCategorySelectListItem(c)));
            Request = new AddEditMovieRequest();
        }

        public AddEditMovieViewModel()
        {
            
        }

        private SelectListItem CreateCategorySelectListItem(Category category)
        {
            return new SelectListItem()
            {
                Text = category.CategoryName,
                Value = category.Id.ToString(),
                Selected = Category == category.Id.ToString()
            };
        }
    }
}
