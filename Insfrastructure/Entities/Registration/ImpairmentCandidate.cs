using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Parameters.Impairements;
using Insfrastructure.Entities.Security;

namespace Insfrastructure.Entities.Registration
{
    public class ImpairmentCandidate
    {
        public int ImpairmentCandidateID { get; set; }
        public int Session { get; set; }
        public int CandidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }
        public int? ImpairmentID { get; set; }
        public virtual Impairment? Impairment { get; set; }

        public int? ImpairmentDegreeID { get; set; }
        public virtual ImpairmentDegree? ImpairmentDegree { get; set; }

        public int? ImpairmentSupportID { get; set; }
        public virtual ImpairmentSupport? ImpairmentSupport { get; set; }

    }

}



