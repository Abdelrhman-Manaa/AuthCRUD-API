using System.Collections;
using Task2_Api.Models;

namespace Task2_Api.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(byte id);
        Task<Category>Add(Category category);
        Category Update(Category category);
        Category Delete(Category category);
        Task <bool> IsValid (byte id);
    }
}
