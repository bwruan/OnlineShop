using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Api.Models
{
    public class AddAddressRequest
    {
        public long AddressId { get; set; }

        public string CustomerName { get; set; }

        public string UnitStreet { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public long AccountId { get; set; }
    }
}
