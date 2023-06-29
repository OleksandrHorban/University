using System;
using System.Collections.Generic;



namespace MVVM_Pet_2
{
    public partial class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public int PetId { get; set; }
        public  List<Pet> Pets { get; set; }
    }
}
