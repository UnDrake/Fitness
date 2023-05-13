using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Service.Implementations;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessArchitecture.Controllers
{
    public class ProductToListController : Controller 
    {
        private readonly IProductToListService addedProductService;
        public ProductToListController(IProductToListService addedProductService)
        {
            this.addedProductService = addedProductService;
        }


        public async Task<IActionResult> CreateAdd(int ID)
        {
            var addProduct = new ProductToList()
            {
                addedAccountEmail = User.Identity.Name,
                productID = ID,
            };
            var product = await addedProductService.Create(addProduct);
            if (product.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("GetProducts", "Product");
            }
            ViewBag.Description = product.Description;
            ViewBag.StatusCode = ((int)product.StatusCode);
            return View("Error");
        }


        public async Task<IActionResult> DeleteAdd(int ID)
        {
            var product = await addedProductService.Delete(ID);
            if (product.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("GetProducts", "ProductList");
            }
            ViewBag.Description = product.Description;
            ViewBag.StatusCode = ((int)product.StatusCode);
            return View("Error");
        }
    }
}