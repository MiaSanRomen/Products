using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Products.Configurations;
using Products.Data;
using Products.Data.DataTransfer;
using Products.Data.Models;
using Products.Interfaces;
using Products.Repositories;
using Products.ViewModels;
using System.Data;
using System.Diagnostics;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        private const string _newProductName = "Новый продукт";
        private const int _sampleImageId = 8;
        private const int _unknownCategoryId = 4;

        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IMapper mapper, IProductsRepository productsRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index(string searchName)
        {
            var products = searchName.IsNullOrEmpty() ? await _productsRepository.GetAllAsync() : await _productsRepository.GetSpecificAsync(searchName);
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }

            var productsDto = _mapper.Map<List<ProductDto>>(products);
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return View(new ProductsViewModel(productsDto, categoriesDto));
        }

        [Authorize(Roles = CustomRoles.AdministratorOrAdvanced)]
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != 0)
            {
                var product = await _productsRepository.GetAsync(id);
                if (product != null)
                {
                    var productDto = _mapper.Map<ProductDto>(product);
                    return View(new RemoveProductViewModel(productDto));
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var product = await _productsRepository.GetAsync(id);
                await UpdateCategoryCountAsync(product.CategoryId, false);
                await _productsRepository.DeleteAsync((int)id);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [Authorize(Roles = CustomRoles.AdministratorOrAdvanced)]
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
                var product = await _productsRepository.GetDetails((int)id);
                if (product != null)
                {
                    var productDto = _mapper.Map<ProductDto>(product);
                    return View(new EditProductViewModel(productDto, productDto.CategoryId, categoriesDto));
                }
            }
            else
            {
                ProductDto productDto = new ProductDto()
                {
                    Name = _newProductName,
                    ImageId = _sampleImageId,
                    CategoryId = _unknownCategoryId
                };
                return View(new EditProductViewModel(productDto, productDto.CategoryId, categoriesDto, true));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel.Product);
            if (product.ProductId != 0)
            {
                await _productsRepository.UpdateAsync(product);
                await UpdateCategoryCountAsync(productViewModel.CategoryId, false);
            }
            else
            {
                await _productsRepository.AddAsync(product);
            }

            await UpdateCategoryCountAsync(productViewModel.Product.CategoryId);

            return RedirectToAction("Index");
        }

        private async Task UpdateCategoryCountAsync(int id, bool isGrown = true)
        {
            var category = await _categoryRepository.GetAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            if(isGrown)
            {
                categoryDto.Count++;
            }
            else
            {
                categoryDto.Count--;
            }

            category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.TrackerClearAsync();
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
