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
        private readonly StarCinemaContext context;

        public CommentRepository(StarCinemaContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Comment>> PaginatedComments(int movieId, int page, int itemsPerPage)
        {
            var movie = await this.context.Movies.Include(m => m.Comments)
                                                 .FirstOrDefaultAsync(m => m.Id == movieId);

            IEnumerable<Comment> comments = movie.Comments
                                         .AsQueryable()
                                         .OrderByDescending(m =>m.AddedDate)
                                         .Skip((page - 1) * itemsPerPage)
                                         .Take(itemsPerPage)
                                         .ToList();
            return comments;

        }
    }    
}
