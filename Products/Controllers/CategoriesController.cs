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
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }

            var records = _mapper.Map<List<CategoryDto>>(categories);
            return View(new CategoriesViewModel(records));
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryRepository.GetDetails(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return View(new CategoryDetailsViewModel(categoryDto));
        }
    }
}
