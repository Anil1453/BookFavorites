using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookFavorites.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public IFormFile Image {  get; set; }
        public string ImageURL { get; set; }

    }
}
