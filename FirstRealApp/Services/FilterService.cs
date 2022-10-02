using FirstRealApp.Models;
using FirstRealApp.Models.PoodleEntity;
using Microsoft.EntityFrameworkCore;

namespace FirstRealApp.Services
{
    public class FilterService : IFilterService
    {
        private readonly AppDbContext _context;


        public FilterService(AppDbContext context)
        {
            _context = context;
        }

        private IQueryable<Poodle> Template()
        {
            var poodles = _context.Poodles;
            var colors = _context.PoodleColors;
            IQueryable<Poodle> query;
            return query = from p in poodles join c in colors on p.PoodleColorId equals c.Id select p;
        }


        public IQueryable<Poodle> FilterSizeAndColor(string size, string color)
        {
            var query = Template();

            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(color))
            {
                return query.Where(x => x.PoodleSize.Name.Equals(size) && x.PoodleColor.Name.Equals(color)).OrderBy(x => x.Id);
            }

            if (!string.IsNullOrEmpty(size) && string.IsNullOrEmpty(color))
            {
                return query.Where(x => x.PoodleSize.Name.Equals(size)).OrderBy(x => x.Id);

            }

            if (!string.IsNullOrEmpty(color) && string.IsNullOrEmpty(size))
            {
                return query.Where(x => x.PoodleColor.Name.Equals(color)).OrderBy(x => x.Id);
            }

            else return query;

        }

        public async Task<List<Poodle>> FilterDate(DateTime dateMin, DateTime dateMax)
        {
           var query = await _context.Poodles.Where(x => x.DateOfBirth > dateMin && x.DateOfBirth < dateMax).ToListAsync();
            return query;
        }
    }
}
