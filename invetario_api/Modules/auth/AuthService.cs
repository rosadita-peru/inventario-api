using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Jwt;
using invetario_api.Modules.auth.dto;
using invetario_api.Modules.auth.response;
using invetario_api.utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace invetario_api.Modules.auth
{
    public class AuthService : IAuthService
    {
        private Database _db;
        private JwtUtils _jwt;

        public AuthService(Database db, JwtUtils jwt) { 
            _db = db;
            _jwt = jwt;
        }

        public async Task<LoginResponse?> login(LoginDto loginDto)
        {
            var findUser = await _db.users
                .Where(u => u.email == loginDto.email)
                .FirstOrDefaultAsync();

            if (findUser == null)
            {
                throw new HttpException(401, "Invalid email or password");
            }
            
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.password, findUser.password);

            if(!isPasswordValid)
            {
                throw new HttpException(401, "Invalid email or password");
            }


            var token = _jwt.generateJwt(findUser);

            return new LoginResponse
            {
                token = token,
                user = findUser
            };
        }
    }
}
