using AppModel.Models;
using DataBaseComplete;

namespace AppComplete.Services
{
    public class BookAuthorServices
    {
        private readonly ApplicationDbContext _context;

        public BookAuthorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(int bookId, int authorId)
        {
            var bookAuthor = new Book_Author
            {
                BookId = bookId,
                AuthorId = authorId
            };

            _context.Add(bookAuthor);
            _context.SaveChanges();
        }
    }
}
