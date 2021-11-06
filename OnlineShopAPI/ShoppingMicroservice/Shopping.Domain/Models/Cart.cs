using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Models
{
    public class Cart
    {
        public long CartId { get; set; }

        public long ItemId { get; set; }

        public int Amount { get; set; }
    }
}
