using P01_BillsPaymentSystem.Data.Models.Enums;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public Guid? BankAccountId { get; set; }
        public Guid? CreditCardId { get; set; }
        public string? Type { get; set; }
        public Guid UserId { get; set; }

        public BankAccount? BankAccount { get; set; }
        public CreditCard? CreditCard { get; set; }
        public User? User { get; set; }
    }
}
