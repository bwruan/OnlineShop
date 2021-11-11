using System;
using System.Collections.Generic;

#nullable disable

namespace Shopping.Infrastructure.Repository.Entities
{
    public partial class Cart
    {
        public long CartId { get; set; }
        public long ItemId { get; set; }
        public int Amount { get; set; }
        public long AccountId { get; set; }

        public virtual Item Item { get; set; }
    }
}
