using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class MovieListingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }

        public MovieListingViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Category = movie.Category.CategoryName;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}
