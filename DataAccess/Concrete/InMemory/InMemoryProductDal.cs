using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // Oracle vt, Sql Server vt, Postgres vt veya Mongo Db den geliyormuş gibi manuel ürün ekliyoruz.
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Kalem",UnitPrice=10,UnitsInStock=50 },
            new Product{ProductId=2,CategoryId=1,ProductName="Kitap",UnitPrice=10, UnitsInStock= 70},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=18,UnitsInStock=10},
            new Product{ProductId=4,CategoryId=2,ProductName="Bilgisayar",UnitPrice=15,UnitsInStock=5},
            new Product{ProductId=4,CategoryId=2,ProductName="Usb",UnitPrice=100,UnitsInStock=60 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {            
            // LINQ ve lambda kullandık. 
            // p harfi foreachda ki takma adımıza denk gelir.
            // Id gibi tek sonuç döndüren sorgularda SingleOrDefault kullanılır.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // select işlemini LINQ ile yapıyoruz.
            // where koşulu ile içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul.
            Product productToUpdete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdete.ProductName = product.ProductName;
            productToUpdete.CategoryId = product.CategoryId;
            productToUpdete.UnitPrice = product.UnitPrice;
            productToUpdete.UnitsInStock = product.UnitsInStock;            

        }

    }
}
