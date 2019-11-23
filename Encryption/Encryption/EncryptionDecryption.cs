using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class EncryptionDecryption
    {
        public static String encrypt(String plain, String passPhrase = "mhFarid159357@#^%")
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                RijndaelManaged rmCrypto = getRijndael(passPhrase);
                using (CryptoStream cryptStream = new CryptoStream(memoryStream, rmCrypto.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(plain);
                    cryptStream.Write(bytes, 0, bytes.Length);
                    cryptStream.FlushFinalBlock();
                    memoryStream.Flush();
                    System.Diagnostics.Debug.WriteLine(memoryStream.ToArray().Length);
                    System.Diagnostics.Debug.WriteLine(plain);
                    var data = memoryStream.ToArray();
                    string output = Convert.ToBase64String(data);
                    return output;
                }
            }
            catch (Exception) { return ""; }
        }

        public static String decrypt(String cipher, String passPhrase = "mhFarid159357@#^%")
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(cipher);
                MemoryStream memoryStream = new MemoryStream(bytes);
                RijndaelManaged rmCrypto = getRijndael(passPhrase);
                using (CryptoStream cryptStream = new CryptoStream(memoryStream, rmCrypto.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    cryptStream.Flush();
                    memoryStream.Flush();
                    return Encoding.Unicode.GetString(decryptedBytes).Trim('\0');
                }
            }
            catch (Exception) { return ""; }
        }

        private static RijndaelManaged getRijndael(String passPhrase)
        {
            RijndaelManaged rmCrypto = new RijndaelManaged();
            HashAlgorithm hash = MD5.Create();
            byte[] salt = hash.ComputeHash(Encoding.Unicode.GetBytes(passPhrase));
            Rfc2898DeriveBytes pwd = new Rfc2898DeriveBytes(passPhrase, salt);
            byte[] key = pwd.GetBytes(rmCrypto.KeySize / 8);
            byte[] iv = pwd.GetBytes(rmCrypto.BlockSize / 8);
            rmCrypto.Key = key;
            rmCrypto.IV = iv;
            rmCrypto.Mode = CipherMode.CBC;
            rmCrypto.Padding = PaddingMode.PKCS7;
            return rmCrypto;
        }
    }
}
