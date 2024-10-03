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
    public interface ISubDivisionStore 
    {
        public SubDivisionModel? CreateSubDivision(SubDivisionModel SubDivisionModel);
        public SubDivisionModel? GetSubDivisionById(int id);
        public IEnumerable<SubDivisionModel>? GetAllSubDivisions();
        public SubDivisionModel? UpdateSubDivision(SubDivisionModel SubDivisionModel);
        public bool DeleteSubDivision(int id);
    }
}
