using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.AddressModels
{
    public class AddressFactory
    {
        public Address GetAddress(AddressViewModel addressViewModel)
        {
            return new Address()
            {
                BuildingNumber = addressViewModel.BuildingNumber,
                City = addressViewModel.City,
                PostalCode = addressViewModel.PostalCode,
                Street = addressViewModel.Street
            };
        }
    }
}
