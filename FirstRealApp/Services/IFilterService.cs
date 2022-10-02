using FirstRealApp.Models;
using FirstRealApp.Models.PoodleEntity;

namespace FirstRealApp.Services
{
    public interface IFilterService
    {
   
        public IQueryable<Poodle> FilterSizeAndColor(string size, string color);

        public Task<List<Poodle>> FilterDate(DateTime dateMin, DateTime dateMax);
    }
}
