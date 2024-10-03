using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Localisation
{
    public class DivisionModel
    {
        public int DivisionID { get; set; }

        [StringLength(100)]

        public string DivisionCode { get; set; }
        public string DivisionLabel { get; set; }
        public int RegionID { get; set; }

        public virtual RegionModel? Region { get; set; }

    }

}
