using Task2_Api.Models;

namespace Task2_Api.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll(byte categotyid = 0 );
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);

    }
}
