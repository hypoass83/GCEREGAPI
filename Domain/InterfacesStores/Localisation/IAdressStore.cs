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
    public interface IAdressStore 
    {
        public bool CreateAdress(AdressModel AdressModel);
        public AdressModel? GetAdressById(int id);
        public IEnumerable<AdressModel>? GetAllAdresss();
        public bool UpdateAdress(AdressModel AdressModel);
        public bool DeleteAdress(int id);
    }
}
