using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;

namespace Insfrastructure.Entities.Security
{

    public class Mouchard
    {
        public int MouchardID { get; set; }

        public DateTime MoucharDate { get; set; }

        public string? SneackHour { get; set; }

        public int? UserID { get; set; }
        public virtual User? User { get; set; }

        public string? MoucharAction { get; set; }

        public string? MoucharDescription { get; set; }

        public string? MoucharOperationType { get; set; }

        public string? MoucharProcedureName { get; set; }

        public string? MoucharHost { get; set; }

        public string? MoucharHostAdress { get; set; }

        public int? ExamcentreID { get; set; }
        public virtual ExamCentre? Examcentre { get; set; }

        public DateTime MoucharBusinessDate { get; set; }
    }
}

