using System;

namespace Shopping.Domain.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        public int OrderNum { get; set; }

        public DateTime PurchaseDate { get; set; }

        public long AccountId { get; set; }

        public long ItemId { get; set; }

        public Item OrderedItem { get; set; }

        public int Amount { get; set; }
    }
}
