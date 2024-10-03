using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Localisation
{
    public class Division
    {
        public int DivisionID { get; set; }
        public int DivisionCode { get; set; }
        public required string DivisionName { get; set; }
        [StringLength(2)]
        public string? DivisionTag { get; set; }
        public int RegionID { get; set; }
        public virtual Region? Region { get; set; }
        
    }

}
