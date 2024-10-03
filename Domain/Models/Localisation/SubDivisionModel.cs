using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Localisation
{
    public class SubDivisionModel
    {
        public int SubDivisionID { get; set; }
        [StringLength(100)]

        public string SubDivisionCode { get; set; }
        public string SubDivisionLabel { get; set; }
        public int DivisionID { get; set; }

        public virtual DivisionModel? Division { get; set; }
    }

}
