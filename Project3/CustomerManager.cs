using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class CustomerManager
    {
        public CustomerManager()
        {
            customers = new List<Customer>()
            {
                new Customer{Id=1,FirstName="Esra",LastName="Koç",City="Ankara",Email="esra@dzsdz" },
                new Customer{Id=2,FirstName="Derin",LastName="Yılmaz",City="İstanbul",Email="derin@dzsdz" },
                new Customer{Id=3,FirstName="Ahmet",LastName="Çelik",City="Balıkesir",Email="ahmet@dzsdz" }
            };
        }
        List<Customer> customers;

        public List<Customer> GetAll()
        {
            return customers;
        }
        public void Add(Customer customer)
        {
            customers.Add(customer);
        }
    }
}

