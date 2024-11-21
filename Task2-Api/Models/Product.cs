namespace Task2_Api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Edition {  get; set; }
        public double Price { get; set; }
        public byte CategoryId { get; set; }
        public Category Category{ get; set; }
    }
}
