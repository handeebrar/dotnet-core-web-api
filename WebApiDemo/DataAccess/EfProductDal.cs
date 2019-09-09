using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess
{
    //ileri zamanlarda ef yerine başka bir framework kullanırsak api bundan etkilenmez bu class sayesinde(dependency injection)
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
        
    }
}
