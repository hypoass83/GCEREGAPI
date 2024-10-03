using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;

namespace Insfrastructure.Entities.Security
{
    public class TimeTable
    {
        public int TimeTableID { get; set; }
        public int Session { get; set; }
        public int ExamID { get; set; }
        public virtual Exam? Exam { get; set; }

        public int SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }

        public int PaperNumber { get; set; }
        public DateTime ExamDate { get; set; }
        [StringLength(10)]
        public required string ExamMoment { get; set; }

        public int? ExamHours { get; set; }
        public int? ExamMinutes { get; set; }
        public string? StartRmq { get;  set; }
        public DateTime StartDate { get; set; }

    }

}



