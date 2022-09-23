using FirstRealApp.Models.PoodleEntity;

namespace FirstRealApp.Interfaces
{
    public interface IPoodleColorsRepository
    {

         IQueryable<PoodleColor> GetAllColors();

         PoodleColor GetById(int id);

         void AddColor(PoodleColor color);

         void RemoveColor(PoodleColor color);




    }
}
