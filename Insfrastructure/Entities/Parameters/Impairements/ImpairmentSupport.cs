using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Security;

namespace Insfrastructure.Entities.Parameters.Impairements
{
    public class ImpairmentSupport
    {
        public int ImpairmentSupportID { get; set; }
        public required string SupportType { get; set; }
        public string? SupportDesc { get; set; }
        public int? ImpairmentID { get; set; }
        public virtual Impairment? Impairment { get; set; }

    }

}



