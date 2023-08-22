
namespace P01_BillsPaymentSystem.App
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System.Globalization;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.Migrate();
                Seed(db);
            }

            var userId = int.Parse(Console.ReadLine());
            UserDetails(userId);

            userId = int.Parse(Console.ReadLine());
            var billAmount = decimal.Parse(Console.ReadLine());
            PayBills(userId, billAmount);
            UserDetails(userId);

        }

        private static void PayBills(int userId, decimal amount)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                var bankAcounts = db.PaymentMethods.Where(pm => pm.UserId == userId)
                    .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                    .Select(pm => pm.BankAccount).ToList();
                var creditCards = db.PaymentMethods.Where(pm => pm.UserId == userId)
                    .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                    .Select(pm => pm.CreditCard).ToList();
                var bankAvailability = bankAcounts.Select(ba => ba.Balance).Sum();
                var creditCardAvailability = creditCards.Select(cc => cc.LimitLeft).Sum();
                if (amount > bankAvailability + creditCardAvailability)
                {
                    Console.WriteLine("Insufficient funds!");
                    return;
                }
                else
                {
                    for (int i = 0; i < bankAcounts.Count && amount > 0; i++)
                    {
                        if (amount <= bankAcounts[i].Balance)
                        {
                            bankAcounts[i].Withdrow(amount);
                            amount = 0;
                            db.SaveChanges();
                            return;
                        }
                        else
                        {
                            var amountPart = bankAcounts[i].Balance;
                            bankAcounts[i].Withdrow(amountPart);
                            amount -= amountPart;
                        }
                    }
                    for (int i = 0; i < creditCards.Count && amount > 0; i++)
                    {
                        if (amount <= creditCards[i].LimitLeft)
                        {
                            creditCards[i].Withdrow(amount);
                            amount = 0;
                            db.SaveChanges();
                            return;
                        }
                        else
                        {
                            var amountPart = creditCards[i].LimitLeft;
                            creditCards[i].Withdrow(amountPart);
                            amount -= amountPart;
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
        private static void UserDetails(int userId)
        {
            using (var db = new BillsPaymentSystemContext())
            {

                var user = db.Users
                    .Where(u => u.UserId == userId)
                    .Select(u => new
                    {
                        Name = $"{u.FirstName} {u.LastName}",
                        CreditCards = u.PaymentMethods
                                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                                        .Select(pm => pm.CreditCard)
                                        .ToList(),
                        BankAccounts = u.PaymentMethods
                                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                                        .Select(pm => pm.BankAccount)
                                        .ToList()
                    }).FirstOrDefault();
                if (user == null)
                {
                    Console.WriteLine($"User with id {userId} not found!");
                    return;
                }
                Console.WriteLine($"User: {user.Name}");
                var bankAccounts = user.BankAccounts;
                if (bankAccounts.Any())
                {
                    Console.WriteLine("Bank Accounts:");
                    foreach (var item in bankAccounts)
                    {
                        Console.WriteLine($"-- ID: {item.BankAccountId}");
                        Console.WriteLine($"--- Balance: {item.Balance}");
                        Console.WriteLine($"--- Bank: {item.BankName}");
                        Console.WriteLine($"--- SWIFT: {item.SwiftCode}");
                    }
                }
                var creditCards = user.CreditCards;
                if (creditCards.Any())
                {
                    Console.WriteLine("Credit Cards:");
                    foreach (var card in creditCards)
                    {
                        Console.WriteLine($"-- ID: {card.CreditCardId}");
                        Console.WriteLine($"--- Limit: {card.Limit}");
                        Console.WriteLine($"--- Money Owed: {card.MoneyOwed}");
                        Console.WriteLine($"--- Limit Left: {card.LimitLeft}");
                        Console.WriteLine($"--- Expiration Date: {card.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
                    }
                }
            }
        }

        private static void Seed(BillsPaymentSystemContext db)
        {
            using (db)
            {
                string[] usersFirstNames = new[] { "Guy", "Kevin", "Roberto", "Rob", "Thierry", "David" };
                string[] usersLastNames = new[] { "Gilbert", "Brown", "Tamburello", "Walters", "Bradley", "Dobney" };
                string[] emails = new[] { "Guy1@gmail.com", "Kevin77@yahoo.com", "Roberto6@yahoo.com", "Rob999@abv.bg", "Thierry7@gmail.com", "David99@gmail.com" };
                string[] passwords = new[] { "ala99bala", "ehoo49", "123", "456", "drundrun", "789" };
                string[] bankNames = new[] { "UnionBank", "ING", "FirstInvestBank", "DSK", "SwissBank", "OBB" };
                string[] swifts = new[] { "UBBGBGSF", "INGBBGSF", "FINBBGSF", "DSKBBGSF", "SWSWSF", "OBBBBGSF" };
                DateTime expirationDate = DateTime.Now.AddMonths(18);
                for (int i = 0; i < emails.Length; i++)
                {
                    var user = new User()
                    {
                        FirstName = usersFirstNames[i],
                        LastName = usersLastNames[i],
                        Email = emails[i],
                        Password = passwords[i]
                    };
                    var balance = 400 + i * 100;
                    var bankAccount = new BankAccount(balance, bankNames[i], swifts[i]);

                    decimal limit = 500 * (i + 1);
                    decimal moneyOwed = 100 * i;
                    var creditCard1 = new CreditCard(limit, moneyOwed, expirationDate.AddMonths(i));

                    limit = 1000 * (i + 1);
                    moneyOwed = 200 * i;
                    var creditCard2 = new CreditCard(limit, moneyOwed, expirationDate.AddMonths(i + 12));

                    var paymentMethods = new PaymentMethod[]
                    {
                    new PaymentMethod()
                    {
                        User = user,
                        BankAccount = bankAccount,
                        Type = PaymentMethodType.BankAccount
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCard1,
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCard2,
                        Type = PaymentMethodType.CreditCard
                    }
                    };
                    //db.Users.Add(user);
                    //db.BankAccounts.Add(bankAccount);
                    //db.CreditCards.Add(creditCard1);
                    //db.CreditCards.Add(creditCard2);
                    db.PaymentMethods.AddRange(paymentMethods);
                }
                db.SaveChanges();
            }
        }
    }

}
