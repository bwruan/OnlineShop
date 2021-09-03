using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Api.Models
{
    public class UpdateAddressRequest
    {
        public long AddressId { get; set; }

        public string NewShipping { get; set; }
    }
}
