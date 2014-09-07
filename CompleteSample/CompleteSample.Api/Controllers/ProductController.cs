using CompleteSample.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CompleteSample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        private static readonly ISet<Product> Products = new HashSet<Product>();

        static ProductController()
        {
            Products.Add(new Product
            {
                Name = "Darjeeling Samabeong",
                Price = 8.2M
            });
            Products.Add(new Product
            {
                Name = "Darjeeling Arya",
                Price = 36M
            });
            Products.Add(new Product
            {
                Name = "Sencha Bio",
                Price = 10.5M
            });
            Products.Add(new Product
            {
                Name = "Thé des Lords",
                Price = 6.5M
            });
            Products.Add(new Product
            {
                Name = "Earl Grey Premium",
                Price = 7.1M
            });
        }

        [HttpGet]
        [ResponseType(typeof(Product[]))]
        [Route("")]
        public IHttpActionResult Retrieve()
        {
            var products = Products.ToArray();

            return Ok(products);
        }

        [HttpGet]
        [ResponseType(typeof(Product))]
        [Route("{id:int}", Name = "GetProduct")]
        public IHttpActionResult Retrieve(int id)
        {
            var query = from p in Products
                        where p.Id == id
                        select p;
            var product = query.FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Products.Add(product);

                return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Create(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                var query = from p in Products
                            where p.Id == id
                            select p;
                var result = query.FirstOrDefault();

                if (result == null)
                {
                    return NotFound();
                }

                result.Name = product.Name;
                result.Price = product.Price;

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Create(int id)
        {
            var query = from p in Products
                        where p.Id == id
                        select p;
            var result = query.FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            Products.Remove(result);

            return Ok();
        }
    }
}
