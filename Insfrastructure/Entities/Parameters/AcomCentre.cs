using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;

namespace Insfrastructure.Entities.Security
{
    public class AcomCentre
    {
        public int AcomCentreID { get; set; }
        public required string AcomCentreCode { get; set; }
        public string? AcomCentreName { get; set; }
        public string? AbbreviatedName { get; set; }
        [StringLength(2)]
        public string? DivTag { get; set; }
        
        public int AdressID { get; set; }
        public virtual Adress? Adress { get; set; }
       
    }

}



