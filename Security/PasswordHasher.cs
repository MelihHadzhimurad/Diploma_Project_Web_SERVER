using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Smart_Tire_app_Server.Security
{
    public class PasswordHasher(IConfiguration configuration)
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        private readonly HashAlgorithmName Alghorithm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] fixSalt = Encoding.UTF8.GetBytes(configuration["FixedSalt"]);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, fixSalt, Iterations, Alghorithm, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }
    }
}
