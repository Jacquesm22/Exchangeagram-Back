using ExchangeAGram.Application.Common.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ExchangeAGram.Infrastructure.Services
{
    public class BasicHashService : IHashService
    {
        public string Hash(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText)) 
            {
                return plainText;
            }

            StringBuilder sb = new();
            foreach (byte b in GetHash(plainText))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private static byte[] GetHash(string inputString)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
    }
}
