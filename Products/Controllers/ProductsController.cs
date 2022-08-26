using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Data;
using Products.Data.DataTransfer;
using Products.Interfaces;
using Products.Repositories;
using Products.ViewModels;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IMapper mapper, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productsRepository.GetAllAsync();
            if (products == null)
            {
                return NotFound();
            }

            var records = _mapper.Map<List<ProductDto>>(products);
            return View(new ProductsViewModel(records));
        }
    }
}
