﻿using Core.EntityFreamework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.ProductId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStok = p.UnitsInStock };
                return result.ToList();
            }
           
        }
    }
}
