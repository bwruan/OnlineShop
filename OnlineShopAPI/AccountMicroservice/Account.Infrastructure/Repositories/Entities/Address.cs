namespace Account.Infrastructure.Repositories.Entities
{
    public class Address
    {
        public long AddressId { get; set; }

        public string Shipping { get; set; }

        public long AccountId { get; set; }
    }
}
