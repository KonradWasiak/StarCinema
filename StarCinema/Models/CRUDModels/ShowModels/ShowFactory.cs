using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class ShowFactory
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public ShowFactory(IMovieRepository movieRepository, ICinemaHallRepository cinemaHallRepository)
        {
            _movieRepository = movieRepository;
            _cinemaHallRepository = cinemaHallRepository;
        }

        public Show CreateShow(AddEditShowRequest request)
        {
            return new Show()
            {
                Date = request.Date,
                Movie = _movieRepository.FindMovie(request.MovieId),
                Bookings = new List<Booking>(),
                Hall = _cinemaHallRepository.FindCinemaHall(request.HallId)
            };
        }
    }
}
