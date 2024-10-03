using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Registration
{
    public class BannedCandidate
    {
       public int BannedCandidateID { get; set; }

        public int BannedSession { get; set; }
        public int BannedExamCode { get; set; } 
        public long BannedCandNumber { get; set; }
        public long MinesecMatricule { get; set; }
        public required string CandName { get; set; }
        public int Duration { get; set; }
    }

}