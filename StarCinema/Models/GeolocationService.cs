using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StarCinema.Models
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<Coordinates> GetCoordinates(string city, string street, string buildingNumber)
        {
            var client = new HttpClient();
            var searchString = city.Normalize(NormalizationForm.FormC) + "%20" +
                               street.Normalize(NormalizationForm.FormC) + "%20" + buildingNumber;
            var url = "https://eu1.locationiq.com/v1/search.php?key=pk.186dc62dcbc221b7bd0349087c37df5f&q=" +
                      searchString + "&format=json";
            var content = await client.GetStringAsync(url);
            var json = JArray.Parse(content).FirstOrDefault();

            return new Coordinates()
            {
                Lat = json["lat"].ToString(),
                Lon = json["lon"].ToString()
            };
        }
    }
}
