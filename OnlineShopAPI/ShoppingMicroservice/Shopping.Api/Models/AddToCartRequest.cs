﻿namespace Shopping.Api.Models
{
    public class AddToCartRequest
    {
        public long AccountId { get; set; }

        public long ItemId { get; set; }

        public int Amount { get; set; }
    }
}
