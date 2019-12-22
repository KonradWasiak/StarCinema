using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class CommentFactory
    {
        private readonly IUserRepository _usrRepo;

        public CommentFactory(IUserRepository usrRepo)
        {
            _usrRepo = usrRepo;
        }

        public async Task<Comment> GetComment(CommentViewModel comment)
        {
            var user = await this._usrRepo.GetUser(comment.Username);
            return new Comment
            {
                Content = comment.Comment,
                User = user,
                AddedDate = comment.AddedDate
            };

        }
    }
}
