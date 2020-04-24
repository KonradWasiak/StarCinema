using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class AddEditShowViewModel
    {
        public AddEditShowRequest Request { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public List<SelectListItem> Halls { get; set; }

        public AddEditShowViewModel()
        {
            
        }
        public AddEditShowViewModel(List<CinemaHall> halls, int movieId)
        {
            MovieId = movieId;
            Request = new AddEditShowRequest();
            Halls = new List<SelectListItem>();
            halls.ForEach(c => Halls.Add(CreateHallSelectListItem(c)));
        }

        private SelectListItem CreateHallSelectListItem(CinemaHall hall)
        {
            return new SelectListItem()
            {
                Text = hall.Cinema.Address.City + "(" + hall.Cinema.Address.Street + "): " + hall.Name,
                Value = hall.Id.ToString(),
                Selected = hall.Id == HallId
            };
        }
    }
}
