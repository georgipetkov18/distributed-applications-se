using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace InvestmentManagerApi.Shared.Utils
{
    public static class PasswordManager
    {
        public static string HashPassword(string password)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: new byte[] { 7, 5, 3, 4 },
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
