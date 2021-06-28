using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TrainingTracking.Entities;
using TrainingTracking.Helpers;
using TrainingTracking.Models;

namespace TrainingTracking.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _dbContext;

        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }

        public (string username, string token)? Authenticate(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var generatedToken = tokenHandler.WriteToken(token);

            return (user.Username, generatedToken);
        }

        public Entities.User Register(CreateUserModel user)
        {
            var createUser = new Entities.User
            {
                FullName = user.FullName,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };

            _dbContext.Users.Add(createUser);
            _dbContext.SaveChanges();
            return createUser;
        }
    }
}