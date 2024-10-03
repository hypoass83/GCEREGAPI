using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Security;

namespace Insfrastructure.Entities.Parameters
{
    public class SpecSubject 
    {
        public int SpecSubjectID { get; set; }
        public int ExamID { get; set; }
        public virtual Exam? Exam { get; set; }

        public int SpecialtyID { get; set; }
        public virtual Specialty? Specialty { get; set; }

        public int SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }

        public int SubjectGroupID { get; set; }
        public virtual SubjectGroup? SubjectGroup { get; set; }
        public bool Iscompulsory { get; set; } 
    }
}