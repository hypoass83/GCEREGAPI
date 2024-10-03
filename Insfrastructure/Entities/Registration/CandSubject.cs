using Insfrastructure.Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Registration
{
    public class CandSubject
    {
        public int CandSubjectID { get; set; }
        public int Session { get; set; }
        public int CandidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }

        public int SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }
    }

}