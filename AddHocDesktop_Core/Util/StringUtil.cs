using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Security;
using System.Security.Cryptography;

/// <summary>
/// Summary description for StringUtil
/// </summary>
namespace AdHocDesktop.Core
{
    public class StringUtil
    {
        public static string ComputeMD5(string src)
        {
            return ComputeMD5(new UnicodeEncoding().GetBytes(src));
        }

        public static string ComputeMD5(byte[] src)
        {
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(src);
            string md5 = BitConverter.ToString(hash);
            md5 = md5.Replace("-", "");
            return md5;
        }
    }
}