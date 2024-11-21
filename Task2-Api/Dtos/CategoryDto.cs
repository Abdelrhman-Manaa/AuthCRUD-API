namespace Task2_Api.Data
{
    public class CategoryDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
