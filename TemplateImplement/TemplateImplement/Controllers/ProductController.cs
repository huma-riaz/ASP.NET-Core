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
        [HttpPost]
        public IActionResult Add(Products prod)
        {
            if (ModelState.IsValid)
            {
                _context.tbl_products.Add(prod);
                _context.SaveChanges();
                TempData["success"] = "Product added successfully";
                return RedirectToAction("Index", "Product");
            }
            return View(prod);
        }

        public IActionResult Edit(Guid id)
        {
            var products = _context.tbl_products.Find(id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Products prod)
        {
            _context.tbl_products.Update(prod);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(Guid ID)
        {
            var prod = _context.tbl_products.Find(ID);
            _context.tbl_products.Remove(prod);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
           // return View(); 
        }

        public IActionResult View(Guid ID)
        {
            var product = _context.tbl_products.Find(ID);
            return View();
        }
        

    }
}
