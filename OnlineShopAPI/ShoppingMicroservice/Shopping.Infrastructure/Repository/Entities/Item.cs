using System;
using System.Collections.Generic;

#nullable disable

namespace Shopping.Infrastructure.Repository.Entities
{
    public partial class Item
    {
        public Item()
        {
            Carts = new HashSet<Cart>();
        }

        public long ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public byte[] Picture { get; set; }
        public int ItemType { get; set; }
        public long SellerId { get; set; }

        public virtual ItemType ItemTypeNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
