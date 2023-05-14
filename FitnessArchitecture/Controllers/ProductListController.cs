using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessArchitecture.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IProductListService productListService;
        public ProductListController(IProductListService productListService)
        {
            this.productListService = productListService;
        }

        public async Task<IActionResult> GetProducts()
        {
            var products = await productListService.GetProducts(User.Identity.Name);
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