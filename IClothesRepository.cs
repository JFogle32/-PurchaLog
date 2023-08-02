// MyCloset/Repositories/ClothesRepository.cs

using MyCLOSET.Models;

namespace MyCloset.Repositories
{
    public interface IClothesRepository
    {
        List<Clothes> GetAll();
        Clothes GetById(int id);
    }
}