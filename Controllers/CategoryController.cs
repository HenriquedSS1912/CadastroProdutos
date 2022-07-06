using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var categories = Category.ListAll();
            return View(categories);
        }

        public IActionResult Detail(int id = 0)
        {
            var category = Category.Get(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            category.Save();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            Category.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
