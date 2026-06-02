using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class RepozytoriumPamiecioweService : IGetDataService, IFormSubmitService
    {
        private int _idGenerator = 1;
        private readonly List<Gra> _data;

        public RepozytoriumPamiecioweService()
        {
            _data = new List<Gra>
            {
                new Gra { Id = _idGenerator++, Tytul = "Wiedźmin 3", Cena = 129.99m, DataPremiery = new DateTime(2015, 5, 19) },
                new Gra { Id = _idGenerator++, Tytul = "Cyberpunk 2077", Cena = 199.99m, DataPremiery = new DateTime(2020, 12, 10) },
                new Gra { Id = _idGenerator++, Tytul = "Minecraft", Cena = 89.99m, DataPremiery = new DateTime(2011, 11, 18) },
                new Gra { Id = _idGenerator++, Tytul = "Grand Theft Auto V", Cena = 149.99m, DataPremiery = new DateTime(2013, 9, 17) },
                new Gra { Id = _idGenerator++, Tytul = "The Elder Scrolls V: Skyrim", Cena = 119.99m, DataPremiery = new DateTime(2011, 11, 11) }
            };
        }

        public List<Gra> Get() => _data.ToList();

        public Gra? GetById(int id) => _data.FirstOrDefault(x => x.Id == id);

        public bool Post(string tytul, decimal cena, DateTime dataPremiery)
        {
            _data.Add(new Gra { Id = _idGenerator++, Tytul = tytul, Cena = cena, DataPremiery = dataPremiery });
            return true;
        }

        public bool Put(int id, string tytul, decimal cena, DateTime dataPremiery)
        {
            var gra = _data.FirstOrDefault(x => x.Id == id);
            if (gra == null) return false;
            gra.Tytul = tytul;
            gra.Cena = cena;
            gra.DataPremiery = dataPremiery;
            return true;
        }
    }
}