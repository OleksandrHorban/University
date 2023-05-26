using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        private decimal balance;
        public BankAccount() { }
        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SwiftCode = swiftCode;
        }
        public int BankAccountId { get; set; }
        public decimal Balance
        {
            get { return this.balance; }
            private set
            {
                if (balance < 0)
                {
                    throw new Exception("Balance must be positive!");
                }
                this.balance = value;
            }
        }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Withdrow(decimal moneyToDrow)
        {
            this.Balance -= moneyToDrow;
        }

        public void Deposit(decimal moneyToDeposit)
        {
            this.Balance += moneyToDeposit;
        }
    }

}
