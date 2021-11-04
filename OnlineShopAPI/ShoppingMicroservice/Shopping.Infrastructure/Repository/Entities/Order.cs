using System;
using System.Collections.Generic;

#nullable disable

namespace Shopping.Infrastructure.Repository.Entities
{
    public partial class Order
    {
        public long OrderId { get; set; }
        public int OrderNum { get; set; }
        public long CartId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
