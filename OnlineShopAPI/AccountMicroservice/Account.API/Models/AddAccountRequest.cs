namespace Account.API.Models
{
    public class AddAccountRequest
    {
        public long AccountId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
