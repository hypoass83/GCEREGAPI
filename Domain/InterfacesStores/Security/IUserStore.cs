using Domain.DTO;
using Domain.Models;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesStores.Security
{
    public interface IUserStore
    {
        public UserModel? GetUserByLoginAndPAssword(string email, string password);
        public Task<UserModel?> CreateUser(UserCreateDTO userModel);
        public UserModel? GetUserById(int id);
        public IEnumerable<UserModel>? GetAllUsers();

        public IEnumerable<UserModel>? GetUsersWithLowerAccessLevel(int userId);
        public UserModel? UpdateUser(UserCreateDTO userModel);
        public bool DeleteUser(int id);
        public bool ChangePassword(int id, ChangePasswordRequestDto changePasswordRequestDto);


    }
}
