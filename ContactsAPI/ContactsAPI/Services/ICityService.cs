using ContactsAPI.Models;

namespace ContactsAPI.Services
{
    public interface ICityService
    {

        public IEnumerable<City> Get();

    }
}
