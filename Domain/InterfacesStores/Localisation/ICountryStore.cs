using Domain.Models;
using Domain.Models.Localisation;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesStores.Localisation
{
    public interface ICountryStore 
    {
        public CountryModel? CreateCountry(CountryModel CountryModel);
        public CountryModel? GetCountryById(int id);
        public IEnumerable<CountryModel>? GetAllCountrys();
        public CountryModel? UpdateCountry(CountryModel CountryModel);
        public bool DeleteCountry(int id);
    }
}
