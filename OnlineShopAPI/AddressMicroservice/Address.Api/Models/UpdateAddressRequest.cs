using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Api.Models
{
    public class UpdateAddressRequest
    {
        public long AddressId { get; set; }

        public string NewCustomer { get; set; }

        public string NewUnitStreet { get; set; }

        public string NewCity { get; set; }

        public string NewState { get; set; }

        public string NewZipcode { get; set; }
    }
}
