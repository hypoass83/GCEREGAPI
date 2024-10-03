using Domain.Models;
using Domain.InterfacesStores.Security;
using Domain.InterfacesServices.Security;
using Domain.InterfacesStores.Localisation;
using Domain.Models.Localisation;

namespace Application.Service.Localisation
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionStore _DivisionStore;

        public DivisionService(IDivisionStore DivisionService)
        {
            _DivisionStore = DivisionService;
        }

        public DivisionModel? CreateDivision(DivisionModel Division)
        {
            return _DivisionStore.CreateDivision(Division);
        }

        public DivisionModel? GetDivisionById(int DivisionId)
        {
            return _DivisionStore.GetDivisionById(DivisionId);
        }

        public IEnumerable<DivisionModel>? GetAllDivisions()
        {
            return _DivisionStore.GetAllDivisions();
        }

        public  DivisionModel? UpdateDivision(DivisionModel DivisionModel)
        {
            return _DivisionStore.UpdateDivision(DivisionModel);
        }

        public bool DeleteDivision(int idDivision)
        {
            return _DivisionStore.DeleteDivision(idDivision);
        }

    }
}
