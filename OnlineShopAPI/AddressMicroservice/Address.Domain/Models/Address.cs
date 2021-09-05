using System;
using System.Collections.Generic;
using System.Text;

namespace Address.Domain.Models
{
    public class Address
    {
        public long AddressId { get; set; }

        public string Shipping { get; set; }

        public long AccountId { get; set; }

        public UserAccount User { get; set; }
    }
}
