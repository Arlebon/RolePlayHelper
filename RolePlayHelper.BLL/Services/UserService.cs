using Isopoh.Cryptography.Argon2;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;
namespace RolePlayHelper.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User newUser )
        {
            if (_userRepository.ExistByUsername(newUser.UserName) || _userRepository.ExistByEmail(newUser.Email)) 
            {
                throw new Exception("User with this username or email already exists");
            }

            newUser.Password = Argon2.Hash(newUser.Password);
            _userRepository.Add(newUser);
        }

        public User Login(string login, string password)
        {
            User? user = _userRepository.GetPasswordByUsernameOrMail(login);

            if (user == null)
            {
                throw new Exception("login failed");
            }

            if (!Argon2.Verify(user.Password, password))
            {
                throw new Exception("login failed");
            }

            return user;
        }
    }
}
