using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Models
{
    public class AddToCartRequest
    {
        public long ItemId { get; set; }

        public int Amount { get; set; }
    }
}
