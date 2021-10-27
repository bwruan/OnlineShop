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
	
        public string BillingName { get; set; }
	
        public string BillingUnit { get; set; }

        public string BillingCity { get; set; }
        
        public string BillingState { get; set; }
        
        public string BillingZipcode { get; set; }
        
        public long CardType { get; set; }
        
        public long AccountId { get; set; }
    }
}
