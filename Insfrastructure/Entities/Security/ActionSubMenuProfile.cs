using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Security
{
    public class ActionSubMenuProfile
    {
        public int ActionSubMenuProfileID { get; set; }
        public bool Delete { get; set; } = true;
        public bool Add { get; set; } = true;
        public bool Update { get; set; } = true;
        public int SubMenuID { get; set; }
        public virtual SubMenu? SubMenu { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile? Profile { get; set; }
    }
}
