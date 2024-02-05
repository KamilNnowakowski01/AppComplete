using AppModel.Models;
using DataBaseComplete;
using Microsoft.EntityFrameworkCore;

namespace AppComplete.Services
{
    public class PublisherServices
    {
        private readonly ApplicationDbContext _context;

        public PublisherServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAll()
        {

            var publishers =
               _context.Publisher
               .Include(b => b.Books)
              .ToList();

            return publishers;
        }

        public Publisher GetById(int id)
        {
            var publisher = 
                _context.Publisher
                .Include(b => b.Books)
                .FirstOrDefault(p => p.PublisherId == id);

            return publisher;
        }

        public void Create(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher));
            }

            _context.Publisher.Add(publisher);
            _context.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher));
            }

            _context.Publisher.Update(publisher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var publisher = _context.Publisher.Find(id);
            if (publisher != null)
            {
                _context.Publisher.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}
