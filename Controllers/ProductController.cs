using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroProdutos.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = Product.ListAll();

            return View(products);
        }

        [HttpGet]
        public IActionResult Detail(int id = 0)
        {
            var product = Product.Get(id);
            var categorias = Category.ListAll();
            ViewBag.CategoryId = new SelectList(categorias, "Id", "Nome", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Product.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
