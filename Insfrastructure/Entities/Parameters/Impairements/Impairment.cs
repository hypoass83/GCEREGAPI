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
    public class Impairment
    {
        public int ImpairmentID { get; set; }
        public required string ImpairmentType { get; set; }
        public string? ImpairmentDesc { get; set; }
       
    }

}



