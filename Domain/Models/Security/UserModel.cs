using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Models.Parameters;

namespace Domain.Models.Security
{
    public class UserModel : PeopleModel
    {
        public string Code { get; set; }
        public string? UserLogin { get; set; }
        public string? UserPassword { get; set; }
        public int UserAccessLevel { get; set; }
        public bool UserAccountState { get; set; }
        public int JobID { get; set; }
        public virtual JobModel? Job { get; set; }

        public int ExamCentreID { get; set; }
         public virtual ExamCentreModel? ExamCentre { get; set; }


        public int? ProfileID { get; set; }
        public virtual ProfileModel? Profile { get; set; }
    }
}
