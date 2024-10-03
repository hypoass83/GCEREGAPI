// using Application.Domain;
using Domain.DTO;
using Domain.Models;
using Domain.InterfacesStores.Security;
using Microsoft.AspNetCore.Mvc;
using Domain.InterfacesServices.Security;
using Domain.Models.Security;
using Microsoft.AspNetCore.Authorization;
using Domain.InterfacesStores.Parameters;
using Domain.Models.Parameters;
using Domain.InterfacesServices.Sms;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _smsService;
        private readonly IConfiguration _configuration;

        public SmsController(ISmsService smsService, IConfiguration configuration)
        {
            _smsService = smsService;
            _configuration = configuration;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendSms([FromBody] SmsRequest smsRequest)
        {
            if (smsRequest == null || string.IsNullOrEmpty(smsRequest.UserPhone))
            {
                return BadRequest(new { Status = false, Message = "Invalid SMS request" });
            }
            var result = await _smsService.SendSmsAsync(smsRequest.UserPhone, smsRequest.Message);
            return result switch
            {
                200 => Ok(new { Status = true, Message = "SMS sent successfully!" }),
                100 => Conflict(new { Status = false, Message = "SMS already sent to this customer!" }),
                2 => Unauthorized(new { Status = false, Message = "Unauthorized access!" }),
                201 => BadRequest(new { Status = false, Message = "Insufficient balance!" }),
                404 => BadRequest(new { Status = false, Message = "Invalid request!" }),
                _ => StatusCode(500, new { Status = false, Message = "An error occurred while sending the SMS." })
            };
        }
    }

}