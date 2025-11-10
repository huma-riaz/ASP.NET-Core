using Microsoft.AspNetCore.Mvc;
using TemplateImplement.Models;

namespace TemplateImplement.Controllers
{
    public class ProductController : Controller
    {
        private readonly TemplateContext _context;
        public ProductController(TemplateContext mycontext)
        {
            this._context = mycontext;
        }

        public IActionResult Index()
        {
            var products = _context.tbl_products.ToList();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }


    }
}
