using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentInfo.Api.Models
{
    public class PaymentRequest
    {
        public long PaymentId { get; set; }

        public string NameOnCard { get; set; }

        public string CardNumber { get; set; }

        public string SecurityCode { get; set; }

        public DateTime ExpDate { get; set; }

        public string BillingName { get; set; }

        public string BillingUnit { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public string BillingZipcode { get; set; }

        public long CardType { get; set; }

        public long AccountId { get; set; }
    }
}
