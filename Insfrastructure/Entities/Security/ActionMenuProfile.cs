using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Security
{
    public class ActionMenuProfile
    {
        public int ActionMenuProfileID { get; set; }
        public bool Delete { get; set; } = true;
        public bool Add { get; set; } = true;
        public bool Update { get; set; } = true;
        public int MenuID { get; set; }
        public virtual Menu? Menu { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile? Profile { get; set; }
    }
}
