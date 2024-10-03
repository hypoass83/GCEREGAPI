using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Localisation
{
    public class Region
    {
        public int RegionID { get; set; }
        public int RegionCode { get; set; }
        public required string RegionName { get; set; }
       
        public int CountryID { get; set; }
        public virtual Country? Country { get; set; }
        
    }

}
