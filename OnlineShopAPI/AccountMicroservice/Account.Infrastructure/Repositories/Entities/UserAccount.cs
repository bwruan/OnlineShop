using System;

namespace Account.Infrastructure.Repositories.Entities
{
    public class UserAccount
    {
        public long AccountId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
