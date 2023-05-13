using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FitnessArchitecture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> GetProduct(int ID)
        {
            var product = await productService.GetProduct(ID);
            if (product.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(product.Data);
            }
            ViewBag.Description = product.Description;
            ViewBag.StatusCode = ((int)product.StatusCode);
            return View("Error");
        }
        

        public IActionResult GetProducts()
        {
            var products = productService.GetProducts();
            if (products.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(products.Data);
            }
            ViewBag.Description = products.Description;
            ViewBag.StatusCode = ((int)products.StatusCode);
            return View("Error");
        }
    }
}
