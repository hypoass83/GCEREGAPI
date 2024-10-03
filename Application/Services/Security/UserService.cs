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
using Insfrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Domain.DTO;


namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserStore _userStore;

        private readonly IConfiguration _configuration;

     
        public UserService(IUserStore userService, IConfiguration configuration)
        {
            _userStore = userService;
            _configuration = configuration;
        }

        public async Task<UserModel?> CreateUser(UserCreateDTO user)
        {
            return await _userStore.CreateUser(user);
        }

        public UserModel? GetUserById(int userId)
        {
            return _userStore.GetUserById(userId);
        }

        public IEnumerable<UserModel>? GetAllUsers()
        {
            return _userStore.GetAllUsers();
        }

        public UserModel? UpdateUser(UserCreateDTO userModel)
        {
            return _userStore.UpdateUser(userModel);
        }

        public bool DeleteUser(int idUser)
        {
            return _userStore.DeleteUser(idUser);
        }

        public UserModel? LoginUser(string login, string password)
        {
            var user = _userStore.GetUserByLoginAndPAssword(login, password);
            return user;
        }

        public LoginResponse GenerateAuthToken(string login, int userId)
        {
            var claims = new[]
            {
                    //new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Email,login),
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                // Add additional claims as needed
                };


            var jwtSettings = _configuration.GetSection("JwtSettings");

            var privatekey = jwtSettings["SecretKey"];
            var key = Encoding.ASCII.GetBytes(privatekey);


            var expiarationDate = DateTime.UtcNow.AddHours(48);
            // Create a signing key and sign the token
            var securityKey = new SymmetricSecurityKey(key);
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Valdoz",
                audience: "Valdoz",
                claims: claims,
                expires: expiarationDate, // Set token expiration as needed
                signingCredentials: creds);

            // Return the serialized token
            string authToken = String.Empty;
            try
            {
                authToken = new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return new LoginResponse { Token=  authToken , ExpierationDate = expiarationDate };
        }

        public bool ChangePassword(int id, ChangePasswordRequestDto changePasswordRequestDto)
        {
            return _userStore.ChangePassword(id,changePasswordRequestDto);
        }

        public IEnumerable<UserModel>? GetUsersWithLowerAccessLevel(int userId)
        {
          return _userStore.GetUsersWithLowerAccessLevel(userId);
        }
    }
}
