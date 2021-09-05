using System;
using System.Collections.Generic;

#nullable disable

namespace Address.Infrastructure.Repository.Entities
{
    public partial class Address
    {
        public long AddressId { get; set; }
        public string Shipping { get; set; }
        public long AccountId { get; set; }
    }
}
