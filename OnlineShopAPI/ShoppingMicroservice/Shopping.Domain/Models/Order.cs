using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        public int OrderNum { get; set; }

        public long CartId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public long AccountId { get; set; }
    }
}
