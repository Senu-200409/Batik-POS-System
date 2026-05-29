using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace POS_System.BusinessLayer
{
    public class AuthKeyGenerator
    {
        public static string GenerateAuthKey(string userId, string roleName, string password, string userName)
        {
            string idPart = userId ?? string.Empty;
            string rolePart = roleName ?? string.Empty;
            string pwdPart = password ?? string.Empty;
            string namePart = userName ?? string.Empty;

            string raw = $"{idPart}|{rolePart}|{pwdPart}|{namePart}";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(raw);
                byte[] hash = sha256.ComputeHash(bytes);

                return string.Concat(hash.Select(b => b.ToString("x2")));
            }
        }
    }
}