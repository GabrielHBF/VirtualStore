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
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "CategoryId", "Name");
            }

            return View(productsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "CategoryId", "Name");

            var result = await _productService.GetByIdAsync(id);
            if (result is null) return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductsViewModel productsViewModel)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "CategoryId", "Name");
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateAsync(productsViewModel);
                if (result is not null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(productsViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ProductsViewModel>> DeleteProduct(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result is null)
            {
                return RedirectToAction("Error");
            }
            return View(result);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<ActionResult> DeleteProductConfirmed(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Error");
        }
    }
}
