using FirstRealApp.Models;
using FirstRealApp.Models.PoodleEntity;
using Microsoft.EntityFrameworkCore;
using FirstRealApp.Services;

namespace FirstRealApp.Repository
{
    public class PoodlesRepository : IPoodlesRepository
    {
        private readonly AppDbContext? _context;


      
        public PoodlesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<PoodleSize> GetAllSizes()
        {
            return _context.PoodleSizes.OrderBy(x => x.Id);
        }

        public void Add(Poodle poodle)
        {
            _context.Poodles.Add(poodle);
            _context.SaveChanges();
        }

        public void Delete(Poodle poodle)
        {
            _context.Poodles?.Remove(poodle);
            _context.SaveChanges();
        }

        public IQueryable<Poodle> GetAllPoodles()
        {
           return _context.Poodles.OrderBy(x => x.Id);
        }

        public Poodle GetById(int id)
        {
            return _context.Poodles.Include(x => x.PoodleColor).Include(x => x.PoodleSize).Include( x=> x.Image).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Poodle poodle)
        {
            _context.Entry(poodle).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }

            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
