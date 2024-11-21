using Task2_Api.Models;

namespace Task2_Api.Data
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Edition { get; set; }
        public double Price { get; set; }

        public string CategoryName { get; set; }
        public byte CategoryId { get; set; }
    }
}
