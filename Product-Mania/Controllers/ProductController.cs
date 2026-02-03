using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_mania.BLL;
using product_mania.DAL;
using Product_Mania.Models;

namespace Product_Mania.Controllers
{
    public class ProductController : Controller
    {
         private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            productService = productService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var products = await productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.AddProductAsync(product);
                    return RedirectToAction(nameof(Index));

                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(product);

        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            await productService.GetProductById(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
