using MyCLOSET.Models;

namespace MyCLOSET.Repositories
{
    public interface IUserRepository
    {
        void Add(Users user);
        List<Users> GetAll();
        Users GetById(int id);
        void Delete(int id);
        void Update(Users user);
    }
}