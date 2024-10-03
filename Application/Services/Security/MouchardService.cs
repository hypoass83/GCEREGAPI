using Domain.Models;
using Domain.InterfacesStores.Security;
using Domain.InterfacesServices.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Security;

namespace Application.Service
{
    public class MouchardService : IMouchardService
    {
        private readonly IMouchardStore _mouchardStore;

        public MouchardService(IMouchardStore mouchardStore)
        {
            _mouchardStore = mouchardStore;
        }

      

        public void LogAction(MouchardModel mouchard)
        {
            _mouchardStore.LogAction(mouchard);
        }
    }
}
