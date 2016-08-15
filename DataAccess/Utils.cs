using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Utils
    {
        public static String HashPassword(String password)
        {
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            using (MD5 md5 = MD5.Create())
            {
                byte[] byteHashedPassword = md5.ComputeHash(bytePassword);
                return Convert.ToBase64String(byteHashedPassword);
            }
        }

    }
}
