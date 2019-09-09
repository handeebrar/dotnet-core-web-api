using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DataAccess;
using WebApiDemo.Entities;

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

        public IActionResult Post(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut] //put operasyonlarında belirtmek gerekli
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId});
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}