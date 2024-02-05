using AppModel.Models;
using DataBaseComplete;
using Microsoft.EntityFrameworkCore;

namespace AppComplete.Services
{
    public class BookServices
    {
        private readonly ApplicationDbContext _context;

        public BookServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            var books = 
                _context.Books
               .Include(b => b.Publisher)
               .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
               .ToList();

            return books;
        }

        public Book GetById(int id)
        {
            var book =
                _context.Books
               .Include(b => b.Publisher)
               .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
               .FirstOrDefault(p => p.BookId == id);

            return book;
        }

        public void Create(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
