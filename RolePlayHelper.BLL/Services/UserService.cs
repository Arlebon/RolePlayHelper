using Isopoh.Cryptography.Argon2;
using RolePlayHelper.BLL.Exceptions.User;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;
using RolePlayHelper.DL.Enums;
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

        public void GetOrCreateAdmin()
        {
            bool adminExists = _userRepository.ExistByUsername("admin");

            if (!adminExists)
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@rph.local",
                    Password = "123",
                    Role = Role.Admin
                };

                admin.Password = Argon2.Hash(admin.Password);

                _userRepository.Add(admin);
            }
        }

        public void GetOrCreateDefaultUser()
        {
            bool defaultExists = _userRepository.ExistByUsername("default");

            if (!defaultExists)
            {
                var defaultUser = new User
                {
                    UserName = "default",
                    Email = "default@web.de",
                    Password = "123",
                    Role = Role.User
                };

                defaultUser.Password = Argon2.Hash(defaultUser.Password);

                _userRepository.Add(defaultUser);
            }
        }
    }
}
