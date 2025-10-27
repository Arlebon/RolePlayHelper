using Isopoh.Cryptography.Argon2;
using RolePlayHelper.BLL.Exceptions.User;
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
                throw new UserAlreadyExistsException("User with this username or email already exists");
            }

            newUser.Password = Argon2.Hash(newUser.Password);
            _userRepository.Add(newUser);
        }

        public User Login(string login, string password)
        {
            User? user = _userRepository.GetPasswordByUsernameOrMail(login);

            if (user == null)
            {
                throw new UserBadRequestException();
            }

            if (!Argon2.Verify(user.Password, password))
            {
                throw new UserBadRequestException();
            }

            return user;
        }

        public User GetOne(int id)
        {
            User? user = _userRepository.GetOne(id);

            if (user == null)
            {
                throw new UserNotFoundException($"User with ID {id} not found");
            }

            return user;
        }
    }
}
