using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IFormSubmitService
    {
        bool Post(string tytul, decimal cena, DateTime dataPremiery);
        bool Put(int id, string tytul, decimal cena, DateTime dataPremiery);
    }
}