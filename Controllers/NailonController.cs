using Microsoft.AspNetCore.Mvc;
using nailon.Entities;

namespace nailon.Controllers
{
    public class NailonController : Controller
    {
        private readonly testContext _context = new testContext();
        public NailonController(testContext testContext)
        {
            _context = testContext;
        }

        public IActionResult Index(){
            var prod = _context.Categories.ToList();
            return View(prod);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat){

            _context.Categories.Add(cat);
            _context.SaveChanges();

            return View("Index");
        }

        [HttpGet]
        public IActionResult Update(int id){
            var cat = _context.Categories.Where(q => q.Id == id).FirstOrDefault();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Update(Category c){
            var cat = _context.Categories.Where(q => q.Id == c.Id).FirstOrDefault();
            cat.Name = c.Name;

            _context.Categories.Update(cat);
            _context.SaveChanges();

            return View("Index");
        }

        
    }
}