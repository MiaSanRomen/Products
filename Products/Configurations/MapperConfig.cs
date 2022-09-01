using AutoMapper;
using Products.Data.DataTransfer;
using Products.Data.Models;
using System.Drawing;
using Image = Products.Data.Models.Image;

namespace Products.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}
