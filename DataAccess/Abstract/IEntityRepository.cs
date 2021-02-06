using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // generic constraint - generic kısıt
    // class : filtresiyle - referans tip olarak kısıtladık.
    // IEntity :IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    // new(): newlenebilir olmalı.
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //filter=null - filtre yapmasanda olur. filtre yapmazsak tüm veriler gelir. 
        //Filtre uygularsak, şu değerler arasındaki veriyi getir gibi uyugularız.
        List<T> GetAll(Expression <Func<T, bool>> filter=null);

        // Filtre yapmak zorundayız. Bir ürünün detayını getir gibi.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
