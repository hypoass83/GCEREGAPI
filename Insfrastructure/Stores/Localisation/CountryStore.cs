using Infrastructure.Entities;
using Insfrastructure.Entities.Localisation;
using Domain.Models.Localisation;
using Domain.InterfacesStores.Localisation;

namespace Infrastructure.Stores.Localisation
{
    public class CountryStore : ICountryStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public CountryStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CountryModel? CreateCountry(CountryModel CountryModel)
        {
            var country = _mapper.Map<Country>(CountryModel);
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return _mapper.Map<CountryModel>(country);
        }

        public CountryModel? GetCountryById(int CountryId)
        {
            var Country = _dbContext.Countries.FirstOrDefault(u => u.CountryID.Equals(CountryId));
            return Country == null ? null : _mapper.Map<CountryModel>(Country);
        }


        public IEnumerable<CountryModel>? GetAllCountrys()
        {
            var Countrys = _dbContext.Countries.ToList();
            return Countrys.Select(_mapper.Map<CountryModel>);
        }

        public CountryModel? UpdateCountry(CountryModel CountryModel)
        {
            var country = _mapper.Map<Country>(CountryModel);
            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();
            return _mapper.Map<CountryModel>(country);
        }

        public bool DeleteCountry(int id)
        {
            var Country = _dbContext.Countries.FirstOrDefault(u => u.CountryID.Equals(id));
            if (Country == null)
            {
                return false;
            }

            _dbContext.Countries.Remove(Country);
            _dbContext.SaveChanges();
            return true;
        }
    }
}