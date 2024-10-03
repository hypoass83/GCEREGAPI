using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Security
{
     public class Job
    {
        public int JobID { get; set; }
        public required string JobCode { get; set; }
        public string? JobLabel { get; set; }
        public string? JobDescription { get; set; }
        
    }
}
