using MyCloset.Models;

namespace MyCLOSET.Repositories
{
    public interface IShoeRepository
    {
        void Add(Shoe shoe);
        void Delete(int id);
        List<Shoe> GetAll();
        Shoe GetById(int id);
        void Update(Shoe shoe);
           }
}