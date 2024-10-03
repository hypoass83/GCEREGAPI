using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Security;

namespace Insfrastructure.Entities.Parameters
{
    public class ExamCentre
    {
        public int ExamCentreID { get; set; }
        public required string ExamCentreCode { get; set; }
        public required string ExamCentreName { get; set; }
        public string? AbbreviatedName { get; set; }
        
        public CentreType CentreType { get; set; }
        public ExamType ExamType { get; set; }
        public SchoolNature SchoolNature { get; set; }

        public bool IsActive { get; set; }
        public bool IsROEOnly { get; set; }

        public string? HostCentreCode { get; set; }

        public int AdressID { get; set; }
        public virtual Adress? Adress { get; set; }

        public int? AcomCentreID { get; set; }
        public virtual AcomCentre? AcomCentre { get; set; }
        public int UserID { get; set; }
        public virtual User? User { get; set; }
    }

    public enum CentreType { Denominational, External, Government, NonDenominational, Special }
    public enum ExamType { GCE, TVEE,NONE }
    public enum SchoolNature { Mixed,Boys, Girls  }
}



