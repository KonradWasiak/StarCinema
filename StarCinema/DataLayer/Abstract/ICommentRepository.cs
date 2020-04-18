using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICommentRepository
    {
        IList<Comment> PaginatedComments(int movieId, int page, int itemsPerPage, string orderBy = "");
        int CommentsCount(int movieId);
        void RemoveComment(int movieId, int commentId);
    }
}
