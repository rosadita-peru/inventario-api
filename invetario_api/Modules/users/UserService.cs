using BCrypt.Net;
using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Jwt;
using invetario_api.Modules.users.dto;
using invetario_api.Modules.users.entity;
using Microsoft.EntityFrameworkCore;

namespace invetario_api.Modules.users
{
    public class UserService : IUserService
    {
        private Database _db;

        public UserService(Database db)
        {
            _db = db;
        }

        public async Task<User?> createUser(UserDto userDto)
        {
            var findEmail = _db.users.FirstOrDefault(u => u.email == userDto.email);

            if (findEmail != null)
            {
                throw new HttpException(409, "Email already Exists");
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(userDto.password);


            User newUser = new User
            {
                email = userDto.email,
                password = hashPassword,
                firstName = userDto.firstName,
                lastName = userDto.lastName
            };
            await _db.users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return newUser;
        }


        public async Task<List<User>> getUsers()
        {
            return await _db.users.ToListAsync();
        }
    }
}
