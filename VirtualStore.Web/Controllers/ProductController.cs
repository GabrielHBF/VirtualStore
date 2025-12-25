using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualStore.Web.Models;
using VirtualStore.Web.Services.Interfaces;

namespace VirtualStore.Web.Controllers
{
    public class ProductController(IProductService productService, ICategoryService categoryService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsViewModel>>> Index()
        {
            var result = await _productService.GetAllAsync();

            if (result is null)
            {
                return View("ERROR");
            }
            return View("Index", result);
        }

        [HttpGet]
        public async Task<ActionResult> CreateProduct()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductsViewModel productsViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateAsync(productsViewModel);
                if (result is null)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "CategoryId", "Name");
            }
            
            return View(productsViewModel);
        }
    }
}
