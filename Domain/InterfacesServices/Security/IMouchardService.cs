using Domain.Models;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesStores.Security
{
    public interface IMouchardService
    {
        public void LogAction(MouchardModel mouchard);
    }
}
