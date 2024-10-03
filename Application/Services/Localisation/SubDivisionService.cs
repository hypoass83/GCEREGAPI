using Domain.Models;
using Domain.InterfacesStores.Security;
using Domain.InterfacesServices.Security;
using Domain.InterfacesStores.Localisation;
using Domain.Models.Localisation;

namespace Application.Service.Localisation
{
    public class SubDivisionService : ISubDivisionService
    {
        private readonly ISubDivisionStore _SubDivisionStore;

        public SubDivisionService(ISubDivisionStore SubDivisionService)
        {
            _SubDivisionStore = SubDivisionService;
        }

        public SubDivisionModel? CreateSubDivision(SubDivisionModel SubDivision)
        {
            return _SubDivisionStore.CreateSubDivision(SubDivision);
        }

        public SubDivisionModel? GetSubDivisionById(int SubDivisionId)
        {
            return _SubDivisionStore.GetSubDivisionById(SubDivisionId);
        }

        public IEnumerable<SubDivisionModel>? GetAllSubDivisions()
        {
            return _SubDivisionStore.GetAllSubDivisions();
        }

        public SubDivisionModel? UpdateSubDivision(SubDivisionModel SubDivisionModel)
        {
            return _SubDivisionStore.UpdateSubDivision(SubDivisionModel);
        }

        public bool DeleteSubDivision(int idSubDivision)
        {
            return _SubDivisionStore.DeleteSubDivision(idSubDivision);
        }

    }
}
