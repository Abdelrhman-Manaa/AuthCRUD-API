using AutoMapper;
//using Task2_Api.Controllers;
using Task2_Api.Data;
using Task2_Api.Models;
namespace Task2_Api.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
