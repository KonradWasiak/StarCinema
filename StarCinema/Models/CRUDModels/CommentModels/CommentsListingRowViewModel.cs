using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class CommentsListingRowViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public DateTime AddedDate { get; set; }

        public CommentsListingRowViewModel(Comment comment)
        {
            Id = comment.Id;
            Username = comment.User.UserName;
            Comment = comment.Content;
            AddedDate = comment.AddedDate;
        }
    }
}
