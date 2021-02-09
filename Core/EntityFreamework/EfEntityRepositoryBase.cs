using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityFreamework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            // using: Nesne kullandıldıktan sonra hemen bellekten siler.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakala. Verikaynağından gönderdiğim prodcuta eşleşitr. Burada ekleme olduğu için eşleştirme olmaz.
                addedEntity.State = EntityState.Added; // ekle
                context.SaveChanges(); // işlemi yap.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakalar. 
                deletedEntity.State = EntityState.Deleted; // sil
                context.SaveChanges(); // işlemi yap.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext contex = new TContext())
            {
                // contex.Set ile Product'a bağlan, filter'a göre datayı getir.
                return contex.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext contex = new TContext())
            {
                // contex.Set ile Product'a bağlan.
                // eğer filter null ise DbSet'deki prodcuta yerleş, oradaki (vt), tüm datayı listeye çevir.
                // Null değilse filter'a göre datayı getir.
                // arka planda select*product dönürür.
                return filter == null ? contex.Set<TEntity>().ToList() : contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakalar. 
                updatedEntity.State = EntityState.Modified; // güncelle
                context.SaveChanges(); // işlemi yap.
            }
        }
    }
}
