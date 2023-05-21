using Bogus;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;

namespace P01_BillsPaymentSystem.Data.Seeding
{
    public static class Seeder
    {
        static Seeder()
        {
            if (Users is null && PaymentMethods is null && CreditCards is null && BankAccounts is null)
            {
                InitializeData();
            }
        }

        public static List<User> Users { get; set; } = null!;
        public static List<PaymentMethod> PaymentMethods { get; set; } = null!;
        public static List<CreditCard> CreditCards { get; set; } = null!;
        public static List<BankAccount> BankAccounts { get; set; } = null!;

        private static void InitializeData()
        {
            Users = GetUserGenerator().Generate(5);
            CreditCards = GetCreditCardGenerator().Generate(5);
            BankAccounts = GetBankAccountGenerator().Generate(5);
            PaymentMethods = GetPaymentMethodGenerator().Generate(5);
        }

        private static Faker<User> GetUserGenerator()
        {
            return new Faker<User>()
                .RuleFor(u => u.UserId, f => Guid.NewGuid())
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.Password, f => f.Internet.Password());
        }

        private static Faker<BankAccount> GetBankAccountGenerator()
        {
            return new Faker<BankAccount>()
                .RuleFor(ba => ba.BankAccountId, f => Guid.NewGuid())
                .RuleFor(ba => ba.Balance, f => f.Random.Decimal(100, 10000))
                .RuleFor(ba => ba.BankName, f => f.Name.Random.Words())
                .RuleFor(ba => ba.SwiftCode, f => f.Finance.CreditCardCvv());
        }

        private static Faker<PaymentMethod> GetPaymentMethodGenerator()
        {
            return new Faker<PaymentMethod>()
            .RuleFor(pm => pm.Id, f => Guid.NewGuid())
            .RuleFor(pm => pm.UserId, f => f.PickRandom(Users).UserId)
            .RuleFor(pm => pm.Type, f => f.Random.Enum<PaymentMethodType>().ToString())
            .RuleFor(pm => pm.BankAccountId, (f, pm) =>
            {
                if (pm.Type is not null && pm.Type.Equals(PaymentMethodType.BankAccount.ToString()))
                {
                    return f.PickRandom(BankAccounts).BankAccountId;
                }

                return null;
            })
            .RuleFor(pm => pm.CreditCardId, (f, pm) =>
            {
                if (pm.Type is not null && pm.Type.Equals(PaymentMethodType.CreditCard.ToString()))
                {
                    return f.PickRandom(CreditCards).CreditCardId;
                }

                return null;
            });
        }

        private static Faker<CreditCard> GetCreditCardGenerator()
        {
            return new Faker<CreditCard>()
                .RuleFor(cc => cc.CreditCardId, f => Guid.NewGuid())
                .RuleFor(cc => cc.Limit, f => f.Random.Decimal(1000, 10000))
                .RuleFor(cc => cc.MoneyOwed, f => f.Random.Decimal(0, 10000))
                .RuleFor(cc => cc.ExpirationTime, f => f.Date.Future(10));
        }
    }
}
