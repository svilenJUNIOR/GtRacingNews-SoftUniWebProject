using GtRacingNews.Services.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace GtRacingNews.Services.Service
{
    public class Hasher : IHasher
    {
        public string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
