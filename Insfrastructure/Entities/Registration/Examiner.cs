using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Parameters.Examiners;
using Insfrastructure.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Registration
{
    public class Examiner
    {
        public int ExaminerID { get; set; }
        public int Session { get; set; }

        [StringLength(5)]
        public string? ROECODE { get; set; }

        public required string FullNames { get; set; }

        public int ExamID { get; set; }
        public virtual Exam? Exam { get; set; }

        public int ExamCentreID { get; set; }
        public virtual ExamCentre? ExamCentre { get; set; }

        public int QualificationID { get; set; }
        public virtual Qualification? Qualification { get; set; }

        public string? Specialisation { get; set; }

        public int IndexCatID { get; set; }
        public virtual IndexCat? IndexCat { get; set; }

        public int? SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }

        public int? SpecialtyID { get; set; }
        public virtual Specialty? Specialty { get; set; }
        public ExaminerType ExaminerType { get; set; }

        public int? RankID { get; set; }
        public virtual Rank? Rank { get; set; }
        public int TeachExperience { get; set; }
        public int MarkExperience { get; set; }

        public int SubDivisionID { get; set; }
        public virtual SubDivision? SubDivision { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
    public enum ExaminerType
    {
        NEW, CURRENT, OLD
    }
}