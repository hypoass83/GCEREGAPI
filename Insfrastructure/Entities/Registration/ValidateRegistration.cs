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
    public class ValidateRegistration
    {
        public int ValidateRegistrationID { get; set; }
        public int Session { get; set; }
        public int CandidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }
        public int PmtCode { get; set; }
        public double AmtPaid { get; set; }
        

    }

}



