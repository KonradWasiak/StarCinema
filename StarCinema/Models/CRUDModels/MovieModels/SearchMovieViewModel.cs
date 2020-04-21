using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class SearchMoviesViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CommentsCount { get; set; }
        public string Description { get; set; }

        public SearchMoviesViewModel(Movie movie)
        {
            MovieId = movie.Id;
            Title = movie.Title;
            Category = movie.Category.CategoryName;
            ReleaseDate = movie.ReleaseDate;
            CommentsCount = movie.Comments.Count;
            Description = movie.Description;
        }
    }
}
