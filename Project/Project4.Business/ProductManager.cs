﻿using Project4.DataAccess;
using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Business
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            if (product.ProductName == "Laptop")
            {
                throw new DuplicateProductException("\tLaptop ekleyemezsiniz!!!\t");
            }
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            //iş kodları yazılır
            return _productDal.GetAll();
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _productDal.GetAllAsync();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
