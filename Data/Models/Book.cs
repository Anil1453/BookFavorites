namespace BookFavorites.Data.Models
{
    public class Book
    {
        public Book()
        {
            Images = new List<Image>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
