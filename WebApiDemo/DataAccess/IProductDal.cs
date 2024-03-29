﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    //product nesnesine erişim bu sınıf üzerinden kontrol edilir
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductModel> GetProductsWithDetails();
    }
}
