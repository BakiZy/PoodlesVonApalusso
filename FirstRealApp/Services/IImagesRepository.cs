using FirstRealApp.Models;

namespace FirstRealApp.Services
{
    public interface IImagesRepository
    {
        Image GetImage(int id);
        IQueryable<Image> GetImages();
        Task AddImage(Image image);
        Task DeleteImage(Image image);

        void UpdateImage(Image image);
    }
}
