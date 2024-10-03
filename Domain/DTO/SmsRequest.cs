using Domain.Models.Localisation;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class SmsRequest
    {
        public string UserPhone { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateEnvoi { get; set; }
        public string TypeSms { get; set; }
        public string Message { get; set; }
        public string SenderId { get; set; }
    }
}
