using System;
using System.Collections.Generic;
using System.Text;

namespace Address.Domain.Models
{
    public class Address
    {
        public long AddressId { get; set; }

        public string CustomerName { get; set; }

        public string UnitStreet { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public long AccountId { get; set; }

        public UserAccount User { get; set; }
    }
}
