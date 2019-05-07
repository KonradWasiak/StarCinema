using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Directory { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Show> Shows { get; set; }
        public IFormFile Image { get; set; }
        public List<SelectListItem> AllCategories { get; set; }
        public MovieViewModel()
        {
            string noInfo = "Not added yet";
            this.Directory = noInfo;
            this.Description = noInfo;
        }

        public MovieViewModel(Movie movie) 
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Directory = movie.Directory;
            this.Description = movie.Description;
            this.Category = movie.Category.CategoryName;
            this.ReleaseDate = movie.ReleaseDate;
            this.Comments = movie.Comments.ToList();
            this.Rates = movie.Rates.ToList();
            this.Shows = movie.Shows.ToList();
        }
        public MovieViewModel(IEnumerable<Category> allCategories)
        {
            this.AllCategories = new List<SelectListItem>();
            foreach(var c in allCategories)
            {
                this.AllCategories.Add(new SelectListItem
                {
                    Value = c.CategoryName,
                    Text = c.CategoryName
                });
            } 
        }

    }
}
