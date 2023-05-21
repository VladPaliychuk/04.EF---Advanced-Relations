using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public Guid CreditCardId { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public decimal? Limit { get; set; }
        public decimal? MoneyOwed { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }
    }
}
