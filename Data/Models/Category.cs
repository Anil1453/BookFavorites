namespace BookFavorites.Data.Models
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }
         public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
