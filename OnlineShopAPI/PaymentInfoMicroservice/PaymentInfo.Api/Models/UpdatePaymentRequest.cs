using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentInfo.Api.Models
{
    public class UpdatePaymentRequest
    {
        public long PaymentId { get; set; }

        public string NewNameOnCard { get; set; }

        public string NewCardNumber { get; set; }

        public string NewSecurityCode { get; set; }

        public DateTime NewExpDate { get; set; }

        public string NewBillingName { get; set; }

        public string NewBillingUnit { get; set; }

        public string NewBillingCity { get; set; }

        public string NewBillingState { get; set; }

        public string NewBillingZipcode { get; set; }

        public long NewCardType { get; set; }
    }
}
