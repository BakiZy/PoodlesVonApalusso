using FirstRealApp.Models;
using FirstRealApp.Models.PoodleEntity;
using FirstRealApp.Services;

namespace FirstRealApp.Repository
{
    public class PoodleColorsRepository : IPoodleColorsRepository
    {

        private readonly AppDbContext? _context;

        public PoodleColorsRepository(AppDbContext context)
        {
            _context = context;
        }
        

        public void AddColor(PoodleColor color)
        {
            _context.PoodleColors.Add(color);
            _context.SaveChanges();
        }

        public IQueryable<PoodleColor> GetAllColors()
        {
            return _context.PoodleColors.OrderBy(x => x.Id);
        }

        public PoodleColor GetById(int id)
        {
            return _context.PoodleColors.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveColor(PoodleColor color)
        {
            _context.PoodleColors.Remove(color);
            _context.SaveChanges();
        }
    }
}
