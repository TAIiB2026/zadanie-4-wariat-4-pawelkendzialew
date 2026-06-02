using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IGetDataService
    {
        List<Gra> Get();
        Gra? GetById(int id);
    }
}