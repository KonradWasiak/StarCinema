using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.CommentModels;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class ShowMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Directory { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int DurationTime { get; set; }
        public string TrailerUrl { get; set; }
        public bool Is3D { get; set; }
        public int ThumbsUpCount { get; set; }
        public int ThumbsDownCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ShowMovieCommentViewModel> Comments { get; set; }
        public int TotalCommentsCount { get; set; }
        public PagingInfo CommentsPagingInfo { get; set; }
        public bool CanUserRate { get; set; }
        public RateViewModel UserRate { get; set; }
        public AddComentViewModel AddComentViewModel { get; set; }


        public ShowMovieViewModel(Movie movie, int commentsPage, int totalCommentsCount)
        {
            Comments = new List<ShowMovieCommentViewModel>();
            TotalCommentsCount = totalCommentsCount;
            Id = movie.Id;
            Title = movie.Title;
            Directory = movie.Directory;
            Description = movie.Description;
            Category = movie.Category.CategoryName;
            DurationTime = movie.DurationTime;
            TrailerUrl = movie.TrailerUrl;
            Is3D = movie.Is3D;
            ThumbsUpCount = movie.Rates.Where(x => x.IfLike).Count();
            ThumbsDownCount = movie.Rates.Where(x => !x.IfLike).Count();
            ReleaseDate = movie.ReleaseDate;
            CommentsPagingInfo = new PagingInfo(movie.Comments.Count, commentsPage);

            AddComentViewModel = new AddComentViewModel();
        }
    }
}
