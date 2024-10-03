using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Localisation
{
    public class SubDivision
    {
        public int SubDivisionID { get; set; }
        public int SubDivisionCode { get; set; }
        public required string SubDivisionName { get; set; }
        public int DivisionID { get; set; }
        public virtual Division? Division { get; set; }
        
    }

}
