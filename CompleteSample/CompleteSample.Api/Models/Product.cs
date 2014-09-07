
namespace CompleteSample.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        private static int _nextId = 1;

        public Product()
        {
            Id = _nextId++;
        }
    }
}
