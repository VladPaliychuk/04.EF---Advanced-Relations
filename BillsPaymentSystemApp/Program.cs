using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.Repositories;
using P01_BillsPaymentSystem.Data;

var connection = "Server=.\\SQLEXPRESS;Initial Catalog=BillsPaymentSystem;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;";

var options = new DbContextOptionsBuilder<BillsPaymentSystemContext>()
                 .UseSqlServer(new SqlConnection(connection))
                 .Options;

var context = new BillsPaymentSystemContext(options);

var user = new UserRepository(context);

Console.Write("Find user by id: ");

//6755bfa3-0918-4304-89c8-2ff90d7c1fe2
var Id = Guid.Parse(Console.ReadLine());
Console.WriteLine();

var User = await user.GetUserById(Id);

Console.WriteLine($"User: {User.UserId} {User.FirstName} {User.LastName}");
Console.WriteLine($"Email: {User.Email}");
Console.WriteLine();

var BankAccount = await user.GetBankAccountByUserId(Id);

Console.WriteLine("Bank Accounts: ");
Console.WriteLine($"The bank`s account ID: {BankAccount.ID}");
Console.WriteLine($"The bank`s account Name: {BankAccount.BankName}");
Console.WriteLine($"The bank`s account balance: {BankAccount.Balance}");
Console.WriteLine($"The bank`s account SwiftCode: {BankAccount.SwiftCode}");
Console.WriteLine();

var CreditCard = await user.GetCreditCardByUserId(Id);

Console.WriteLine($"The credit card`s ID: {CreditCard.CreditCardId}");
Console.WriteLine($"The credit card`s account Limit: {CreditCard.Limit}");
Console.WriteLine($"The credit card`s account MoneyOwed: {CreditCard.MoneyOwed}");
Console.WriteLine($"The credit card`s account ExpirationDate: {CreditCard.ExpirationTime}");
Console.WriteLine();

Console.WriteLine("Press enter to exit");
Console.ReadLine();