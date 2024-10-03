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
    public interface IRegionStore 
    {
        public RegionModel? CreateRegion(RegionModel RegionModel);
        public RegionModel? GetRegionById(int id);
        public IEnumerable<RegionModel>? GetAllRegions();
        public RegionModel? UpdateRegion(RegionModel RegionModel);
        public bool DeleteRegion(int id);
    }
}
