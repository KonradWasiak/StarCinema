using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.BookingModels;
using StarCinema.Models.CRUDModels.BookingModels.Services;

namespace StarCinema.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepository _bookingRepository;
        private IUserRepository _userRepository;
        private readonly IShowRepository _showRepository;
        private readonly IEmailBookingService _emailBookingService;
        private readonly IBookingService _bookingService;

        public BookingController(IBookingRepository bookingRepository, IUserRepository userRepository,
            IShowRepository showRepository, IEmailBookingService emailBookingService,
            IBookingService bookingService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _showRepository = showRepository;
            _emailBookingService = emailBookingService;
            _bookingService = bookingService;
        }

        [Authorize]
        public IActionResult CreateBooking(int showId, string username)
        {
            var booking = new Booking()
            {
                User = _userRepository.GetUser(username),
                Show = _showRepository.GetShow(showId)
            };

            _bookingRepository.AddBooking(booking);
            _emailBookingService.SendBookingConfirmationEmail(_userRepository.GetUser(username).Email, booking);
            var bookingHash = _bookingService.GetBookingHash(booking);

            return View((object) bookingHash);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Bookings(BookingListingRequest request)
        {
            var bookings = _bookingRepository.GetPaginatedBookings(request.Page, request.PageSize, request.OrderBy, request.MovieId).ToList();
            var bookingRows = new List<BookingListingRowViewModel>();
            bookings.ForEach(x => bookingRows.Add(new BookingListingRowViewModel(x)));

            foreach (var booking in bookings)
            {
                var bookingCode = _bookingService.GetBookingHash(booking);
                bookingRows.Where(x => x.Id == booking.Id).FirstOrDefault().Code = bookingCode;
            }

            var bookingsCount = _bookingRepository.MovieBookingsCount(request.MovieId);
            var bookingListingViewModel = new ListingViewModel<BookingListingRowViewModel>(bookingRows, request.Page, bookingsCount, request.OrderBy);

            return View(bookingListingViewModel);
        }
    }
}