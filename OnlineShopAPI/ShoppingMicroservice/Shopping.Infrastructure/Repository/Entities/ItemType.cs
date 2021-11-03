﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Shopping.Infrastructure.Repository.Entities
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        public int ItemTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
