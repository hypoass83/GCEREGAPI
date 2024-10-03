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
using Domain.DTO;
using Domain.InterfacesServices.Sms;
using System.Net;
using Newtonsoft.Json;

namespace Application.Service
{

    public class SmsService : ISmsService
    {
        private readonly HttpClient _httpClient;

        public SmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> SendSmsAsync(string phoneNumber, string text_message)
        {
            var accessToken = "OTyMnbatmUZCRXrEsrQgY3z1xQM=";
            var AppId = "Valdoz";
            // Clean up the phone number
            string userPhone = phoneNumber.Replace(" ", string.Empty);
            userPhone = userPhone.Length == 9 ? userPhone : userPhone.Substring(0, 9);
            userPhone = "+237" + userPhone;

            // Prepare the SMS data
            var message = new
            {
                sender_id = AppId,
                phone = userPhone,
                text = text_message,
                flash = false
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            // Set the authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            // Send the POST request
            var response = await _httpClient.PostAsync("https://api.web2sms237.com/sms/send", jsonContent);
            // Handle response status codes
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return 200; // Success
                case System.Net.HttpStatusCode.Unauthorized:
                    return 2;   // Unauthorized
                case System.Net.HttpStatusCode.PaymentRequired:
                    return 201; // Insufficient balance
                case System.Net.HttpStatusCode.BadRequest:
                    return 404; // Invalid request
                default:
                    return 0;   // Unhandled status
            }
        }
    }
}