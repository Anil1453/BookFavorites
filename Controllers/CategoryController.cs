using BookFavorites.Data;
using BookFavorites.Data.Models;
using BookFavorites.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookFavorites.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            {
                this.db = db; 
            }
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()   //GET
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel model)
        {
            Category category = new Category
            {
                Name = model.Name,
            };
            db.Categories.Add(category);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}
