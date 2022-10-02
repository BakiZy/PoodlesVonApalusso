using FirstRealApp.Models.PoodleEntity;

namespace FirstRealApp.Services
{
    public interface IPoodlesRepository
    {
        public IQueryable<Poodle> GetAllPoodles();

        public IQueryable<PoodleSize> GetAllSizes();

        public Poodle GetById(int id);

        void Add(Poodle poodle);

        void Update(Poodle poodle);

        void Delete(Poodle poodle);




    }
}
