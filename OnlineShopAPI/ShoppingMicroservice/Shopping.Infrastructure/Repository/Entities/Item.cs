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
        public byte[] Picture { get; set; }
        public int ItemTypeId { get; set; }

        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
