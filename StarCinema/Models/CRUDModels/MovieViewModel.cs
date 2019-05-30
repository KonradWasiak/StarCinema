using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        [Range(15, 100, ErrorMessage = "Title must have between 1 and 100 charcters")]
        public string Title { get; set; }
        [Required]
        [Range(15, 100, ErrorMessage = "Directory must have between 1 and 100 charcters")]
        public string Directory { get; set; }
        [Required]
        [Range(15, 2000, ErrorMessage = "Description must have between 1 and 2000 charcters")]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Range(1,1000,ErrorMessage ="Duration time must be between 1 and 1000 minutes")]
        public int DurationTime { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Trailer url time must be between 1 and 1000 minutes")]
        public string TrailerUrl { get; set; }
        [Required]
        public bool Is3D { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Show> Shows { get; set; }
        [Required]
        public IFormFile PosterImage { get; set; }
        [Required]
        public IFormFile BannerImage { get; set; }
        public List<SelectListItem> AllCategories { get; set; }
        public CommentViewModel UserComment { get; set; }
        public RateViewModel UserRate { get; set; }
        public bool CanRate { get; set; }
        public static PagingInfo PagingInfo { get; set; }

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
            this.Is3D = movie.Is3D;
            this.TrailerUrl = movie.TrailerUrl;
            this.DurationTime = movie.DurationTime;
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

        public MovieViewModel(IEnumerable<Category> allCategories, Movie movie)
        {
            this.AllCategories = new List<SelectListItem>();
            foreach (var c in allCategories)
            {
                this.AllCategories.Add(new SelectListItem
                {
                    Value = c.CategoryName,
                    Text = c.CategoryName
                });
            }

            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Directory = movie.Directory;
            this.Description = movie.Description;
            this.Category = movie.Category.CategoryName;
            this.ReleaseDate = movie.ReleaseDate;
            this.Comments = movie.Comments.OrderByDescending(c => c.AddedDate).ToList();
            this.Rates = movie.Rates.ToList();
            this.Shows = movie.Shows.ToList();
            this.Is3D = movie.Is3D;
            this.TrailerUrl = movie.TrailerUrl;
            this.DurationTime = movie.DurationTime;
        }

    }
}
