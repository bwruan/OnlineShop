using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public byte[] Picture { get; set; }
        
        public int ItemTypeId { get; set; }
    }
}
