using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;

namespace Insfrastructure.Entities.Parameters.Impairements
{
    public class ImpairmentDegree
    {
        public int ImpairmentDegreeID { get; set; }
        public required string DegreeName { get; set; }
        public string? DegreeDesc { get; set; }
       
    }

}



