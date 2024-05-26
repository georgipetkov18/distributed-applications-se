using InvestmentManagerApi.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;

namespace InvestmentManagerApi.Shared.Utils
{
    public static class SessionManager
    {
        private static DateTime expiresOn = DateTime.UtcNow;
        private static string token;
        private static User user;

        public static string Token
        {
            get
            {
                if (DateTime.UtcNow > expiresOn)
                {
                    return null;
                }

                return token;
            }
        }

        public static User User 
        {
            get
            {
                if (DateTime.UtcNow > expiresOn || token == null)
                {
                    return null;
                }

                return user;
            }
            private set
            {
                user = value;
            }
        }

        public static void SaveToken(string token, DateTime expiresOn)
        {
            SessionManager.token = token;
            SessionManager.expiresOn = expiresOn;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            user = new User
            {
                Id = Guid.Parse(jwtSecurityToken.Claims.First(claim => claim.Type == "Id").Value),
                Email = jwtSecurityToken.Claims.First(claim => claim.Type == "email").Value,
                Name = jwtSecurityToken.Claims.First(claim => claim.Type == "unique_name").Value,
            };
        }

        public static void ResetSession()
        {
            token = null;
            user = null;
            expiresOn = DateTime.UtcNow;
        }
    }
}
