using FirstRealApp.Models;

namespace FirstRealApp.Interfaces
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
