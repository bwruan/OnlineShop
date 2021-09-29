using System;
using System.Collections.Generic;

#nullable disable

namespace Address.Infrastructure.Repository.Entities
{
    public partial class Address
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
