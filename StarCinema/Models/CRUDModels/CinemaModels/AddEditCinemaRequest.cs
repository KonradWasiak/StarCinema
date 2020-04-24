using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.Models.CRUDModels.CinemaHallModels;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class AddEditCinemaRequest
    {
        public int CinemaId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        public int CinemaHallsCount { get; set; }
        public List<AddEditCinemaHallRequest> CinemaHalls { get; set; }

        public void CreateCinemaHalls()
        {
            CinemaHalls = new List<AddEditCinemaHallRequest>();
            for (int i = 0; i < CinemaHallsCount; i++)
            {
                CinemaHalls.Add(new AddEditCinemaHallRequest());
            }
        }
    }
}
