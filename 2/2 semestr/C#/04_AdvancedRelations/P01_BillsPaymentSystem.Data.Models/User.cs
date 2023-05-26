namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class User
    {
        public User()
        {
            this.PaymentMethods = new HashSet<PaymentMethod>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

    }
}