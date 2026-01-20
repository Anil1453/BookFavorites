using Microsoft.Identity.Client;

namespace BookFavorites.Data.Models
{
    public class Image
    {
        public Image()
        { 
        Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Extension { get; set; }
        public int BookId { get; set; }
       
        public Book Book { get; set; }

    }
}
