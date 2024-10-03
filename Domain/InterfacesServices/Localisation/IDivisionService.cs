using Domain.Models;
using Domain.Models.Localisation;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesServices.Security
{
    public interface IDivisionService
    {
        public DivisionModel?  CreateDivision(DivisionModel DivisionModel);
        public DivisionModel? GetDivisionById(int id);
        public IEnumerable<DivisionModel>? GetAllDivisions();
        public DivisionModel?  UpdateDivision(DivisionModel DivisionModel);
        public bool DeleteDivision(int id);
    }
}


