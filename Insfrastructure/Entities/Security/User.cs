using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Entities.Security
{
    public class User : People
    {
        //public string? Code { get; set; }
        [StringLength(10)]
        public required string UserLogin { get; set; }
        public required string UserPassword { get; set; }
        public int UserAccessLevel { get; set; }
        public bool UserAccountState { get; set; }

        public int JobID { get; set; }
        public virtual Job? Job { get; set; }

        public int? ProfileID { get; set; }
        public virtual Profile? Profile { get; set; }



    }
}
