using BookShopTrainingApp.Core;

namespace BookShopTrainingApp.Application.AddBook
{
    public class AddBookActionResult
    {
        public AddBookActionResult(ActionStatus status, string messge)
        {
            Status = status;
            ErrorMessage = messge;
        }

        public AddBookActionResult(ActionStatus status, BookModel book)
        {
            Status = status;
            Book = book;
        }
        public ActionStatus Status { get; }
        public BookModel Book { get; }
        public string ErrorMessage { get; }
    }
}