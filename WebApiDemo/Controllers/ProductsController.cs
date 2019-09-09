using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        public string Get()
        {
            return "Product1";
        }
    }
}