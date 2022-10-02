using FirstRealApp.Models.PoodleEntity;

namespace FirstRealApp.Services
{
    public interface IPoodleColorsRepository
    {

        IQueryable<PoodleColor> GetAllColors();

        PoodleColor GetById(int id);

        void AddColor(PoodleColor color);

        void RemoveColor(PoodleColor color);




    }
}
