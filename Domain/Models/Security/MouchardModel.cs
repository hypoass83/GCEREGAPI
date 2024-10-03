using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Parameters;


namespace Domain.Models.Security
{

    public class MouchardModel
    {
        public int MoucharID { get; set; }

        public DateTime MoucharDate { get; set; }

        public string SneackHour { get; set; }

        public int? UserID { get; set; }
        public virtual UserModel User { get; set; }

        public string MoucharAction { get; set; }

        public string MoucharDescription { get; set; }

        public string MoucharOperationType { get; set; }

        public string MoucharProcedureName { get; set; }

        public string MoucharHost { get; set; }

        public string MoucharHostAdress { get; set; }

        public int? ExamCentreID { get; set; }
        public ExamCentreModel ExamCentre { get; set; }

        public DateTime MoucharBusinessDate { get; set; }
    }
}

