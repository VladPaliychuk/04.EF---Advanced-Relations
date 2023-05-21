using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.Repositories
{
    public class UserRepository
    {
        private readonly BillsPaymentSystemContext _context;
        public UserRepository(BillsPaymentSystemContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(Guid Id)
        {
            var result = await _context
                .Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == Id);

            if (result is not null) { return result; }
            else { throw new NullReferenceException($"User with {Id} ID was not found!"); }
        }

        public async Task<PaymentMethod> GetPaymentMethodByUserId(Guid Id)
        {
            var paymentMethodResult = await _context
                .Set<PaymentMethod>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == Id);

            if (paymentMethodResult is not null) { return paymentMethodResult; }
            else { throw new NullReferenceException($"User payment method was not found!"); }
        }

        public async Task<BankAccount> GetBankAccountByUserId(Guid Id)
        {
            var PaymentMethod = await GetPaymentMethodByUserId(Id);

            Guid? BankAccountId = Guid.Empty;
            if (PaymentMethod is not null) { BankAccountId = PaymentMethod.BankAccountId; }

            var BankAccountResult = await _context
                .Set<BankAccount>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BankAccountId == BankAccountId);

            if (BankAccountResult is not null) { return BankAccountResult; }
            else { throw new NullReferenceException($"The user bank was not found!"); }
        }

        public async Task<CreditCard> GetCreditCardByUserId(Guid userId)
        {
            var paymentMethodResult = await GetPaymentMethodByUserId(userId);

            Guid? CreditCardId = Guid.Empty;
            if (paymentMethodResult is not null) { CreditCardId = paymentMethodResult.CreditCardId; }

            var CreditCardtResult = await _context
                .Set<CreditCard>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CreditCardId == CreditCardId);

            if (CreditCardtResult is not null) { return CreditCardtResult; }
            else { throw new NullReferenceException($"The user credit card was not found!"); }
        }
    }
}
