
namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    public class CreditCard
    {
        private decimal limit;
        private decimal moneyOwed;
        public CreditCard() { }
        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expirationDate;
        }
        public int CreditCardId { get; set; }
        public decimal Limit
        {
            get { return this.limit; }
            private set
            {
                if (limit < 0)
                {
                    throw new Exception("No limit!");
                }
                this.limit = value;
            }
        }
        public decimal MoneyOwed
        {
            get { return this.moneyOwed; }
            private set
            {
                this.moneyOwed = value;
            }
        }
        public decimal LimitLeft => Limit - MoneyOwed;
        public DateTime ExpirationDate { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Withdrow(decimal moneyToDrow)
        {
            this.MoneyOwed += moneyToDrow;
        }
        public void Deposit(decimal moneyToDeposit)
        {
            this.MoneyOwed -= moneyToDeposit;
        }
    }
}
