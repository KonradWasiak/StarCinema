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

        public Comment CreateComment(AddComentRequest request)
        {
            var user = this._usrRepo.GetUser(request.User);
            return new Comment
            {
                Content = request.Comment,
                User = user,
                AddedDate = DateTime.Now
            };
        }
    }
}
