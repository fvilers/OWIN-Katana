using System.Web.Http;

namespace Middlewares.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = new Product
            {
                Id = id,
                Name = "Darjeeling Samabeong",
                Price = 8.2M
            };

            return Ok(product);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
