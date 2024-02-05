using AppModel.Models;
using DataBaseComplete;
using Microsoft.EntityFrameworkCore;

namespace AppComplete.Services
{
    public class AuthorServices
    {
        private readonly ApplicationDbContext _context;

        public AuthorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            var authors = _context.Author.ToList();

            return authors;
        }

        public Author GetById(int id)
        {
            var author =
                _context.Author
                .FirstOrDefault(p => p.AuthorId == id);

            return author;
        }

        public void Create(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Author.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Author.Update(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Author.Find(id);
            if (author != null)
            {
                _context.Author.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
