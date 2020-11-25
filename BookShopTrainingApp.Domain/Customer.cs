using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string name, string surnmame, string email)
        {
            Name = name;
            Surname = surnmame;
            Email = email; 
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}