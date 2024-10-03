using Domain.Models;
using Domain.InterfacesServices.Security;
using Domain.InterfacesStores.Localisation;
using Domain.Models.Localisation;

namespace Application.Service.Localisation
{
    public class CountryService : ICountryService
    {
        private readonly ICountryStore _CountryStore;

        public CountryService(ICountryStore CountryService)
        {
            _CountryStore = CountryService;
        }

        public CountryModel? CreateCountry(CountryModel Country)
        {
            return _CountryStore.CreateCountry(Country);
        }

        public CountryModel? GetCountryById(int CountryId)
        {
            return _CountryStore.GetCountryById(CountryId);
        }

        public IEnumerable<CountryModel>? GetAllCountrys()
        {
            return _CountryStore.GetAllCountrys();
        }

        public CountryModel? UpdateCountry(CountryModel CountryModel)
        {
            return _CountryStore.UpdateCountry(CountryModel);
        }

        public bool DeleteCountry(int idCountry)
        {
            return _CountryStore.DeleteCountry(idCountry);
        }

    }
}
