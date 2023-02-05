using ContactsAPI.Models;
namespace ContactsAPI.Services
{
    public class CityService : ICityService
    {

        private List<City> _citys = new List<City>()
        {

            new City() { CityId=1, name = "Buenos Aires"},
            new City() { CityId=2, name = "New York"},
            new City() { CityId=3, name = "Springfield"},
            new City() { CityId=4, name = "Texas"},
            new City() { CityId=5, name = "Miami"},
            new City() { CityId=6, name = "Queens"}

        };

        public IEnumerable<City> Get() => _citys;

    }
}
