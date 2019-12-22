using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.AddressModels
{
    public class AddressViewModel
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }

        public AddressViewModel(string city, string street, string postalCode, string buildingNumber)
        {
            City = city;
            Street = street;
            PostalCode = postalCode;
            BuildingNumber = buildingNumber;
        }
        public AddressViewModel(Address address)
        {
            City = address.City;
            Street = address.Street;
            PostalCode = address.PostalCode;
            BuildingNumber = address.BuildingNumber;
        }
        public AddressViewModel()
        {
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(City);
            sb.Append(", ");
            sb.Append(PostalCode);
            sb.Append(", ");
            sb.Append(Street);
            sb.Append(" ");
            sb.Append(BuildingNumber);

            return sb.ToString();
        }
        public Address ToEntity()
        {
            return new Address()
            {
                City = this.City,
                BuildingNumber = this.BuildingNumber,
                PostalCode = this.PostalCode,
                Street = this.Street
            };
        }
    }
}
