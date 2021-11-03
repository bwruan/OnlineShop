using System;

namespace PaymentInfo.Domain.Models
{
    public class Payment
    {
        public long PaymentId { get; set; }

        public string NameOnCard { get; set; }

        public string CardNumber { get; set; }

        public string SecurityCode { get; set; }

        public DateTime ExpDate { get; set; }

        public long CardTypeId { get; set; }

        public long AccountId { get; set; }
    }
}
