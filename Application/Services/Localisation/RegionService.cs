using Domain.Models;
using Domain.InterfacesStores.Security;
using Domain.InterfacesServices.Security;
using Domain.InterfacesStores.Localisation;
using Domain.Models.Localisation;

namespace Application.Service.Localisation
{
    public class RegionService : IRegionService
    {
        private readonly IRegionStore _RegionStore;

        public RegionService(IRegionStore RegionService)
        {
            _RegionStore = RegionService;
        }

        public RegionModel? CreateRegion(RegionModel Region)
        {
            return _RegionStore.CreateRegion(Region);
        }

        public RegionModel? GetRegionById(int RegionId)
        {
            return _RegionStore.GetRegionById(RegionId);
        }

        public IEnumerable<RegionModel>? GetAllRegions()
        {
            return _RegionStore.GetAllRegions();
        }

        public RegionModel? UpdateRegion(RegionModel RegionModel)
        {
            return _RegionStore.UpdateRegion(RegionModel);
        }

        public bool DeleteRegion(int idRegion)
        {
            return _RegionStore.DeleteRegion(idRegion);
        }

    }
}
