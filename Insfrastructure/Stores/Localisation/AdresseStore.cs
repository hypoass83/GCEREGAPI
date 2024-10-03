using Infrastructure.Entities;
using Insfrastructure.Entities.Localisation;
using Domain.Models.Localisation;
using Domain.InterfacesStores.Localisation;

namespace Infrastructure.Stores.Localisation
{
    public class AdressStore : IAdressStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public AdressStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public bool CreateAdress(AdressModel AdressModel)
        {
            _dbContext.Adresses.Add(_mapper.Map<Adress>(AdressModel));
            _dbContext.SaveChanges();
            return true;
        }

        public AdressModel? GetAdressById(int AdressId)
        {
            var Adress = _dbContext.Adresses.FirstOrDefault(u => u.AdressID.Equals(AdressId));
            return Adress == null ? null : _mapper.Map<AdressModel>(Adress);
        }


        public IEnumerable<AdressModel>? GetAllAdresss()
        {
            var Adresss = _dbContext.Adresses.ToList();
            return Adresss.Select(_mapper.Map<AdressModel>);
        }

        public bool UpdateAdress(AdressModel AdressModel)
        {
            _dbContext.Adresses.Update(_mapper.Map<Adress>(AdressModel));
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAdress(int id)
        {
            var Adress = _dbContext.Adresses.FirstOrDefault(u => u.AdressID.Equals(id));
            if (Adress == null)
            {
                return false;
            }

            _dbContext.Adresses.Remove(Adress);
            _dbContext.SaveChanges();
            return true;
        }
    }
}