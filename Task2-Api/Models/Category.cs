namespace Task2_Api.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

    }
}
