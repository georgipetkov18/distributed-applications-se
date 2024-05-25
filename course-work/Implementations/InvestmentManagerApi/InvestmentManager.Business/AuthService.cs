using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Responses.Auth;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared.Exceptions;
using InvestmentManagerApi.Shared.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvestmentManagerApi.Business
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AuthResponse> Authenticate(string email, string password)
        {
            var user = await this._unitOfWork.Users.GetByEmailAndPasswordAsync(email, PasswordManager.HashPassword(password))
                ?? throw new NotFoundException();

            JwtSecurityTokenHandler handler = new();
            var tokenKey = this._configuration["Authentication:TokenKey"] ?? throw new ArgumentNullException("Not working token key");
            var key = Encoding.ASCII.GetBytes(tokenKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new(new Claim[]
                {
                    new(ClaimTypes.Email, email),
                    new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = handler.CreateToken(tokenDescriptor);

            return new AuthResponse
            {
                Token = handler.WriteToken(token),
                ExpiresOn = tokenDescriptor.Expires,
            };
        }
    }
}
