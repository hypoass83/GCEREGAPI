using Domain.DTO;
using Domain.Models;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesServices.Sms
{
    public interface ISmsService
    {
        Task<int> SendSmsAsync(string phoneNumber, string message);
    }

}
