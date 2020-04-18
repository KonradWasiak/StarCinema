using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class ShowMovieCommentViewModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }

        public ShowMovieCommentViewModel(Comment comment)
        {
            Id = comment.Id;
            User = comment.User.UserName;
            Content = comment.Content;
            AddedDate = comment.AddedDate;
        }
    }
}
