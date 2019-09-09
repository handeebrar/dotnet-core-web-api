using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DataAccess;

namespace WebApiDemo.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        IProductDal _productDal;
        public ProductsController(IProductDal productDal) //IProductDal'ın ne olduğunu bilmediği için Startup.cs'teki ConfigureServices()'e gidecek
        {
            _productDal = productDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productDal.Get(p => p.ProductId == productId);

                if (productId != null)
                {
                    return Ok(product);
                }
                return NotFound($"There is no product with Id = {productId}");
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}