using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Abstraction.Interface;
using Asp.Net.Angular.Template.Contract.Base;
using Asp.Net.Angular.Template.Contract.Response;
using Asp.Net.Angular.Template.Service.ApplicationConfiguration;
using Asp.Net.Angular.Template.DataEntity;

namespace Asp.Net.Angular.Template.Service.Account
{
    public class UserAccountService : IUserAccountService
    {
        private const int MaxAllowedRetries = 5;
        private readonly Settings _appSettings;
        //private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public async Task<Result<AuthenticationResponse>> AuthenticateUser(string email, string password)
        {
            if (email != "admin@admin.com" || password != "Password!23")
            {
                Result.Failed(new ApplicationError(Guid.NewGuid(), "Wrond user id or password", ErrorCode.Unauthorized));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var user = new UserAccount
            {
                Email= "admin@admin.com",
                Name = "Admin",
                Role = "Admin"
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(nameof(user.UserAccountId), user.UserAccountId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "Asp.Net.Angular.Template",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var authenticationResponse = new AuthenticationResponse
            {
                AccessToken = tokenHandler.WriteToken(token),
                Email = user.Email,
                UserName = user.Name,
                UserAccountId = user.UserAccountId
            };

            return Result<AuthenticationResponse>.Success(authenticationResponse);


        }
    }
}
