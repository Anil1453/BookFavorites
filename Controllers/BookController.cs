using BookFavorites.Data;
using BookFavorites.Data.Models;
using BookFavorites.Models;
using BookFavorites.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace BookFavorites.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IShortStrings service;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext db, IShortStrings service, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.service = service;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            List<SelectListItem> categories = db.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();
            BookViewModel model = new BookViewModel
            {
                Categories = categories
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            var extansion = Path.GetExtension(model.Image.FileName);
            var dbImage = new Image
            {
                Extension = extansion,
            };
            var physicalPath = $"{webHostEnvironment.WebRootPath}/img/{dbImage.Id}.{dbImage.Extension}";
            using (FileStream fs =new FileStream(physicalPath, FileMode .Create))
            {
                model.Image.CopyTo(fs);
            }

            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Year = model.Year,
                CategoryId = model.CategoryId
            };
            book.Images.Add(dbImage);
            db.Books.Add(book);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult    Details(int id)
        {
            var model = db.Books.Where(x => x.Id == id).Select(z => new BookViewModel
            {

                Title = z.Title,
                Author = z.Author,
                Description = service.GetShort(z.Description, 40),
                Year = z.Year,
                CategoryName = z.Category.Name,
                ImageURL = "/img/" + z.Images.FirstOrDefault().Id + z.Images.FirstOrDefault().Extension
            }).FirstOrDefault();
            return View(model);
        }
            
        
        public IActionResult All()
        {
            List<BookViewModel> model = db.Books.Select(x => new BookViewModel()
            {
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                Year = x.Year,
                CategoryName = x.Category.Name,
            }).ToList();
            return View(model);
         }
        
    
    }
}
