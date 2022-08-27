using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Project4.DataAccess
{
    public class XProductDal : IProductDal
    {
        List<Product> _products;
        public XProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Acer x Bilgisayar", QuantityPerUnit = "32 Gb Ram", UnitPrice = 10000, UnitsInStock = 2 },
                new Product { ProductId = 2, ProductName = "Asus x Bilgisayar", QuantityPerUnit = "32 Gb Ram", UnitPrice = 10000, UnitsInStock = 1 },
                new Product { ProductId = 3, ProductName = "Hp x Bilgisayar", QuantityPerUnit = "32 Gb Ram", UnitPrice = 10000, UnitsInStock = 0 },
                new Product { ProductId = 4, ProductName = "Mac x Bilgisayar", QuantityPerUnit = "32 Gb Ram", UnitPrice = 10000, UnitsInStock = 3 },
                new Product { ProductId = 5, ProductName = "Dell x Bilgisayar", QuantityPerUnit = "32 Gb Ram", UnitPrice = 10000, UnitsInStock = 10 }
            };
        }
        public void Add(Product product)
        {
            //throw new Exception("Veri tabanına bağlanamadı. xxxx şifresi doğru değil.");
            Console.WriteLine("X ile eklendi");
        }

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
