using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace InvestmentManagerApi.Shared.Utils
{
    public static class PasswordManager
    {
        public static string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(128 / 8);
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static bool PasswordIsValid(string rawPassword, string passwordHashed)
        {
            return HashPassword(rawPassword) == passwordHashed;
        }
    }
}
