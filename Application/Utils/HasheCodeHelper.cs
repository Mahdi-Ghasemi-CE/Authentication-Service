using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class HasheCodeHelper
    {
        #region Calculate256Hash

        public static string Calculate256Hash(string value)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(value);
            var hashPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashPassword);
        }

        #endregion

        #region Calculate512Hash

        public static string Calculate512Hash(string value)
        {
            var sha = SHA512.Create();
            var asByteArray = Encoding.Default.GetBytes(value);
            var hashPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashPassword);
        }

        #endregion

        #region Calculate512HashToInt

        public static string Calculate512HashToInt(string value)
        {
            SHA512 md5Hasher = SHA512.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
            int ivalue = BitConverter.ToInt32(hashed, 1);
            if (ivalue < 0)
            {
                ivalue *= -1;
            }
            return ivalue.ToString();
        }

        #endregion
    }
}
