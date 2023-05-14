using System.Security.Cryptography;
using System.Text;

namespace FitnessArchitecture.Domain.Helpers
{
    public static class HashPasswordHelper
    {
        public static string HashPassoword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}