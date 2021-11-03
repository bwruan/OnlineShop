using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentInfo.Api.Models
{
    public class AddPaymentRequest
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
