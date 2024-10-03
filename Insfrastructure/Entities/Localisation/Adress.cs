using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Localisation
{
    public class Adress
    {
        public int AdressID { get; set; }
        public string? AdressPhoneNumber { get; set; }
        public string? AdressCellNumber { get; set; }
        public string? AdressFullName { get; set; }
        public string? AdressEmail { get; set; }
        public string? AdressWebSite { get; set; }
        public string? AdressPOBox { get; set; }
        public string? AdressFax { get; set; }
        public int? SubDivisionID { get; set; }
        public virtual SubDivision? SubDivision { get; set; }


    }

}
