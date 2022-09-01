using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Configurations;
using Products.Data;
using Products.Data.DataTransfer;
using Products.Data.Models;
using Products.Interfaces;
using Products.Repositories;
using Products.ViewModels;
using System.Data;

namespace Products.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductsRepository _productsRepository;

        private int _defaultCategoryId = 4;
        private const string _newCategoryName = "Новый продукт";
        private const int _sampleImageId = 8;

        public CategoriesController(IMapper mapper, ICategoryRepository categoryRepository, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }

            var records = _mapper.Map<List<CategoryDto>>(categories);
            return View(new BaseViewModel(records));
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryRepository.GetDetails(id);
            if (category == null)
            {
                return NotFound();
            }

            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            var records = _mapper.Map<List<CategoryDto>>(categories);
            bool isDefaultCategory = categoryDto.CategoryId == _defaultCategoryId;
            return View(new CategoryDetailsViewModel(categoryDto, isDefaultCategory, records));
        }

        [Authorize(Roles = CustomRoles.Administrator)]
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != 0)
            {
                var category = await _categoryRepository.GetAsync(id);
                if (category != null)
                {
                    var categoryDto = _mapper.Map<CategoryDto>(category);
                    return View(new RemoveCategoryViewModel(categoryDto));
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                await UpdateCategoryProductsAsync((int)id);
                await _categoryRepository.DeleteAsync((int)id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [Authorize(Roles = CustomRoles.Administrator)]
        public async Task<IActionResult> Edit(int? id)
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            if (id != null)
            {
                var category = await _categoryRepository.GetDetails((int)id);
                if (category != null)
                {
                    var categoryDto = _mapper.Map<CategoryDto>(category);
                    return View(new EditCategoryViewModel(categoryDto, categoriesDto));
                }
            }
            else
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    Name = _newCategoryName,
                    ImageId = _sampleImageId
                };
                return View(new EditCategoryViewModel(categoryDto, categoriesDto, true));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel.Category);
            if(category.CategoryId != 0)
            {
                await _categoryRepository.UpdateAsync(category);
            }
            else
            {
                await _categoryRepository.AddAsync(category);
            }

            return RedirectToAction("Details", new { id = category.CategoryId });
        }

        private async Task UpdateCategoryProductsAsync(int id)
        {
            var category = await _categoryRepository.GetDetails(id);
            if (category != null)
            {
                int productsReplaced = 0;
                var categoryDto = _mapper.Map<CategoryDto>(category);
                foreach(var productDto in categoryDto.Products)
                {
                    productDto.CategoryId = _defaultCategoryId;
                    var product = _mapper.Map<Product>(productDto);
                    await _productsRepository.UpdateAsync(product);
                    productsReplaced++;
                }

                if(productsReplaced > 0)
                {
                    var defaultCategory = await _categoryRepository.GetDetails(_defaultCategoryId);
                    if (defaultCategory != null)
                    {
                        var defaultCategoryDto = _mapper.Map<CategoryDto>(defaultCategory);
                        defaultCategoryDto.Count = defaultCategoryDto.Count + productsReplaced;
                        defaultCategory = _mapper.Map<Category>(defaultCategoryDto);
                        _categoryRepository.TrackerClearAsync();
                        await _categoryRepository.UpdateAsync(defaultCategory);
                    }
                }
            }
        }
    }
}
