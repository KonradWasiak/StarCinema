using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class CommentViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage ="You must type in something")]
        [MaxLength(1000,ErrorMessage ="Max comment length is 1000 characters")]
        public string Comment { get; set; }
        public DateTime AddedDate = DateTime.Now;


        public CommentViewModel(Comment comment)
        {
            this.Username = comment.User.UserName;
            this.Comment = comment.Content;
            this.AddedDate = comment.AddedDate;
        }

        public CommentViewModel()
        {

        }
    }

}
