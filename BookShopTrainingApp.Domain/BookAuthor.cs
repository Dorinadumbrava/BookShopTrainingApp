namespace BookShopTrainingApp.Domain
{
    public class BookAuthor
    {
        public BookAuthor() { }
        public BookAuthor(int bookId, int authorId) 
        {
            BookId = bookId;
            AuthorId = authorId;
        }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
    }
}