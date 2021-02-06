using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // using: Nesne kullandıldıktan sonra hemen bellekten siler.
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakala. Verikaynağından gönderdiğim prodcuta eşleşitr. Burada ekleme olduğu için eşleştirme olmaz.
                addedEntity.State = EntityState.Added; // ekle
                context.SaveChanges(); // işlemi yap.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakalar. 
                deletedEntity.State = EntityState.Deleted; // sil
                context.SaveChanges(); // işlemi yap.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                // contex.Set ile Product'a bağlan, filter'a göre datayı getir.
                return contex.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                // contex.Set ile Product'a bağlan.
                // eğer filter null ise DbSet'deki prodcuta yerleş, oradaki (vt), tüm datayı listeye çevir.
                // Null değilse filter'a göre datayı getir.
                // arka planda select*product dönürür.
                return filter == null ? contex.Set<Product>().ToList() : contex.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakalar. 
                updatedEntity.State = EntityState.Modified; // güncelle
                context.SaveChanges(); // işlemi yap.
            }
        }
    }
}
