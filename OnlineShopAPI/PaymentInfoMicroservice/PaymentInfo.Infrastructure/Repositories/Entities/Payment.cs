using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentInfo.Infrastructure.Repositories.Entities
{
    public class Payment
    {
        public long PaymentId { get; set; }

        public string NameOnCard { get; set; }

        public string CardNumber { get; set; }

        public string SecurityCode { get; set; }

        public string ExpDate { get; set; }
        
        public long CardTypeId { get; set; }
        
        public long AccountId { get; set; }
    }
}
