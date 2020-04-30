using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.CommentModels;

namespace StarCinema.Controllers
{
    public class CommentController : Controller
    {
        private readonly  ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IActionResult MovieComments(CommentsListingRequest request)
        {
            var movieComments = _commentRepository.PaginatedComments(request.MovieId, request.Page, request.PageSize, request.OrderBy).ToList();
            var movieCommentsCount = _commentRepository.CommentsCount(request.MovieId);
            var commentsListingViewModelRows = new List<CommentsListingRowViewModel>();
            movieComments.ForEach(x => commentsListingViewModelRows.Add(new CommentsListingRowViewModel(x)));
            var commentsViewModel = new CommentListingViewModel(commentsListingViewModelRows, request.MovieId, request.Page, movieCommentsCount, request.OrderBy);
            return View(commentsViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveComment([FromQuery] RemoveCommentRequest request)
        {
            _commentRepository.RemoveComment(request.MovieId, request.CommentId);
            return RedirectToAction("MovieComments", new CommentsListingRequest(){MovieId = request.MovieId});
        }
    }
}