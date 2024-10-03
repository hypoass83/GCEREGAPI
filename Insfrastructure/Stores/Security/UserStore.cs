using Domain.Models;
using Domain.InterfacesStores.Security;
using Infrastructure.Entities;
using Domain.Models.Security;
using AutoMapper;
using Insfrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Domain.InterfacesServices.Sms;



namespace Infrastructure.Stores.Security
{
    public class UserStore : IUserStore
    {
        private readonly FsContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ISmsService _smsService;
        private static Random random = new Random();

        public UserStore(FsContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher, ISmsService smsService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _smsService = smsService;
        }

        public async Task<UserModel?> CreateUser(UserCreateDTO userModel)
        {
            var user = _mapper.Map<User>(userModel);

            if (user.IsConnected)
            {
                user.UserPassword = GenererCode();

                string welcomeMessage = $"Bonjour et bienvenue chez Valdoz Optique !\n\n" +
                                               $"Votre compte a été créé avec succès. Voici votre mot de passe temporaire : {user.UserPassword}. Nous vous recommandons de vous connecter et de le changer si besoin.\n\n" +
                                               "Chez Valdoz, ça dose !\n\n" +
                                               "À très bientôt,\n" +
                                               "L'équipe Valdoz Optique";
                
                int a = await _smsService.SendSmsAsync(user.AdressPhoneNumber, welcomeMessage);

                if (a != 200)
                {
                    user.UserPassword = "12345678";
                }
            }

            if (user.UserPassword != null)
            {
                user.UserPassword = _passwordHasher.HashPassword(user, user.UserPassword);
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            _dbContext.Entry(user).State = EntityState.Detached;

            return GetUserById(user.GlobalPersonID);
        }

        public UserModel? GetUserByLoginAndPAssword(string login, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserLogin == login);

            if (user == null || user.UserPassword == null)
            {
                return null;
            }

            // check if user is not blocked account
            if (!user.UserAccountState)
            {
                return null;
            }

            // check if his profile is active
            if (user.Profile != null && !user.Profile.ProfileState)
            {
                return null;
            }

            // Vérifier le mot de passe
            var result = _passwordHasher.VerifyHashedPassword(user, user.UserPassword, password);

            return result == PasswordVerificationResult.Success ? _mapper.Map<UserModel>(user) : null;
        }

        public UserModel? GetUserById(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.GlobalPersonID.Equals(userId));
            return user == null ? null : _mapper.Map<UserModel>(user);
        }


        public IEnumerable<UserModel>? GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            return users.Select(_mapper.Map<UserModel>);
        }

        public UserModel? UpdateUser(UserCreateDTO userModel)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.GlobalPersonID == userModel.GlobalPersonID);
            if (existingUser == null)
            {
                return null;
            }

            var user = _mapper.Map<User>(userModel);
            user.UserPassword = existingUser.UserPassword; // Preserve the original password
            // Update other fields
            _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            existingUser.Adress = user.Adress;
            _dbContext.SaveChanges();

            return _mapper.Map<UserModel>(existingUser);
        }



        public bool DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.GlobalPersonID.Equals(id));
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool ChangePassword(int id, ChangePasswordRequestDto changePasswordRequestDto)
        {

            var user = _dbContext.Users.FirstOrDefault(u => u.GlobalPersonID == id);

            if (user == null || user.UserPassword == null)
            {
                return false;
            }

            // Vérifier le mot de passe
            var result = _passwordHasher.VerifyHashedPassword(user, user.UserPassword, changePasswordRequestDto.OldPassword);

            if (result != PasswordVerificationResult.Success)
            {
                return false;
            }

            user.UserPassword = _passwordHasher.HashPassword(user, changePasswordRequestDto.NewPassword);

            _dbContext.SaveChanges();
            return true;

        }

        public IEnumerable<UserModel>? GetUsersWithLowerAccessLevel(int userId)
        {
            var users = _dbContext.Users.ToList();
            var user = GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            var targetUsers = users.Where(u => u.UserAccessLevel < user.UserAccessLevel).ToList();
            return targetUsers.Select(_mapper.Map<UserModel>);
        }


        public string GenererCode(int longueur = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, longueur).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}