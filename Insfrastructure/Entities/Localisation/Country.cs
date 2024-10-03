using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Localisation
{
    public class Country
    {
        public int CountryID { get; set; }
        [StringLength(5)]
        public required string CountryCode { get; set; }
        public required string CountryName { get; set; }

    }

}
