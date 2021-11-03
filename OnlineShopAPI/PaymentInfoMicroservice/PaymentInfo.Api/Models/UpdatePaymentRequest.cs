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

        public string NewExpDate { get; set; }

        public long NewCardTypeId { get; set; }
    }
}
