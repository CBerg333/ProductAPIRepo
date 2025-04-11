using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ProductsAppQA.Models;

namespace ProductsAppQA.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Pea Soup", Category = "Pantry", Price = 2 },
            new Product { Id = 2, Name = "Rubix Cube", Category = "Puzzles", Price = 4.75M },
            new Product { Id = 3, Name = "Scissors", Category = "Tool", Price = 17.99M }
        };


        public ProductController() {
            
        }

        public ProductController(Product[] products)
        {
            this.products = products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(products);
        }

        [HttpGet]
        [Route("api/products/{id:int}")] 
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("api/products/async/{id:int}")]
        public async Task<IHttpActionResult> GetProductAsync(int id)
        {
            var product = await Task.FromResult(products.FirstOrDefault(p => p.Id == id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}