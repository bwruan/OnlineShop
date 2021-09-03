using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Api.Models
{
    public class AddAddressRequest
    {
        public long AddressId { get; set; }

        public string Shipping { get; set; }

        public long AccountId { get; set; }
    }
}
