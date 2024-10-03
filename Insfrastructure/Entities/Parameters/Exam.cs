using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Parameters
{
    public class Exam
    {
        public int ExamID { get;set;}
        public int ExamCode { get;set;}
        public required string ExamName { get;set;}
        public double RegFee { get;set;}
        public double LateEntryFee { get;set;}
        public int MinRegSub { get;set;}
        public int MaxRegSub { get;set;}
        public ExamType ExamType { get; set; }
        public double SubjectFee { get; set; }
        public double PracticalFee { get; set; }
        public int CandNumSeed { get; set; }
        [StringLength(25)]
        public string? RequiredMax { get; set; }
        public bool ReqSpec { get; set; }
    }
}