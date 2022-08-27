﻿using Microsoft.EntityFrameworkCore;
using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.DataAccess
{
    public class EfProductDal : IProductDal
    {
        //List<Product> _products;
        public EfProductDal()
        {
            //_products = new List<Product>
            //{
            //    //    new Product{ProductId=1, ProductName="Acer ef Bilgisayar", QuantityPerUnit="32 Gb Ram", UnitPrice=10000, UnitsInStock=2},
            //    //    new Product{ProductId=2, ProductName="Asus ef Bilgisayar", QuantityPerUnit="32 Gb Ram", UnitPrice=10000, UnitsInStock=1},
            //    //    new Product{ProductId=3, ProductName="Hp ef Bilgisayar", QuantityPerUnit="32 Gb Ram", UnitPrice=10000, UnitsInStock=0},
            //    //    new Product{ProductId=4, ProductName="Mac ef Bilgisayar", QuantityPerUnit="32 Gb Ram", UnitPrice=10000, UnitsInStock=3},
            //    //    new Product{ProductId=5, ProductName="Dell ef Bilgisayar", QuantityPerUnit="32 Gb Ram", UnitPrice=10000, UnitsInStock=10}
            //};
        }
        public void Add(Product product)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public async Task AddAsync(Product entity)
        {
            NorthWindContext context = new NorthWindContext();
            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public void Delete(Product product)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                context.Products.Remove(context.Products.SingleOrDefault(p => p.ProductId == product.ProductId));
                context.SaveChanges();
            }
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAll()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Products.ToList();
            }
            //dispose
        }

        public Task<List<Product>> GetAllAsync()
        {
            NorthWindContext context = new NorthWindContext();
            return context.Products.ToListAsync();
        }

        public Product GetById(int id)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }
        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Product product)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var productToUpdate = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.QuantityPerUnit = product.QuantityPerUnit;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
                productToUpdate.CategoryId = product.CategoryId;

                context.SaveChanges();
            }
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

