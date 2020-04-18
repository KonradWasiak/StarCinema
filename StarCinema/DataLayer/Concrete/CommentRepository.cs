using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly StarCinemaContext _context;

        public CommentRepository(StarCinemaContext context)
        {
            _context = context;
        }
        public IList<Comment> PaginatedComments(int movieId, int page, int itemsPerPage, string orderBy)
        {
            var  comments = new List<Comment>();

            var movieComments = _context.Movies.Where(x => x.Id == movieId)
                .Include(x => x.Comments)
                .Include(x => x.Comments).ThenInclude(c => c.User)
                .FirstOrDefault()
                ?.Comments;

            if (movieComments == null || (!movieComments.Any()))
            {
                return comments;
            }

            switch (orderBy)
            {
                case "AddedDateAsc":
                    comments = movieComments.OrderBy(x => x.AddedDate).ToList();
                    break;
                case "AddedDateDesc":
                    comments = movieComments.OrderByDescending(x => x.AddedDate).ToList();
                    break;
                case "UserAsc":
                    comments = movieComments.OrderBy(x => x.User.UserName).ToList();
                    break;
                case "UserDesc":
                    comments = movieComments.OrderByDescending(x => x.User.UserName).ToList();
                    break;
                default:
                    comments = movieComments.OrderBy(x => x.AddedDate).ToList();
                    break;
            }

            return  comments.Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }

        public int CommentsCount(int movieId)
        {
            var movieComments = _context.Movies.Where(x => x.Id == movieId)
                .Include(x => x.Comments)
                .Include(x => x.Comments).ThenInclude(c => c.User)
                .FirstOrDefault()
                ?.Comments;
            if (movieComments == null)
            {
                return 0;
            }

            return movieComments.Count();
        }

        public void RemoveComment(int movieId, int commentId)
        {
            var comment = _context.Movies.Where(x => x.Id == movieId)
                .Include(x => x.Comments)
                .FirstOrDefault()
                ?.Comments
                .Where(x => x.Id == commentId)
                .FirstOrDefault();

            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }    
}
