using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICommentRepository : IRepository
    {
        Task<IEnumerable<Comment>> PaginatedComments(int movieId, int page, int itemsPerPage);
    }
}
