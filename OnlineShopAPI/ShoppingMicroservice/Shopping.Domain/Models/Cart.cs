namespace Shopping.Domain.Models
{
    public class Cart
    {
        public long CartId { get; set; }

        public long ItemId { get; set; }

        public int Amount { get; set; }

        public long AccountId { get; set; }

        public Item ShopItem { get; set; }
    }
}
