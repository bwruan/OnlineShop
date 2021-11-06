using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain.Models
{
    public class UserAccount
    {
        public long AccountId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }
    }
}
