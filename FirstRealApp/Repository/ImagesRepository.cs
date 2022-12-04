using FirstRealApp.Models;
using FirstRealApp.Models.PoodleEntity;
using FirstRealApp.Services;
using Microsoft.EntityFrameworkCore;

namespace FirstRealApp.Repository
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly AppDbContext _context;
       public ImagesRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public  async Task AddImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    

        public  Image  GetImage(int id)
        {
            return  _context.Images.FirstOrDefault(x => x.Id == id);
            
        }

        public IQueryable<Image> GetImages()
        {
            return _context.Images;
        }

        public void UpdateImage(Image image)
        {
            _context.Entry(image).State = EntityState.Modified;

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
