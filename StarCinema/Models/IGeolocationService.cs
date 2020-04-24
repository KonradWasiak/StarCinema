using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models
{
    public interface IGeolocationService
    {
        Task<Coordinates> GetCoordinates(string city, string street, string buildingNumber);
    }
}
