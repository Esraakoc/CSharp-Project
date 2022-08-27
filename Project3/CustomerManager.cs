using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class CustomerManager
    {
        public CustomerManager()
        {
            customers = new List<Customer>()
            {
                new Customer {Id=1, FirstName="Esra", LastName="Koç",Email="esra@.",City="İstanbul"},
                new Customer {Id=2, FirstName="Furkan", LastName="Şahin",Email="furkan@.",City="Ankara"},
                new Customer {Id=3, FirstName="Ayşe", LastName="Yılmaz",Email="ayşe@.",City="İzmit"},
                new Customer {Id=4, FirstName="Demir", LastName="Demir",Email="sahlih@.",City="Muğla"}
            };
        }

        List<Customer> customers;
        public List<Customer> GetAll()
        {
            //Veritabanına bağlan

            return customers;
        }
        //(int Id,string FirstName.... gibi)
        public void Add(Customer customer)
        {
            customers.Add(customer);
        }
    }
}
