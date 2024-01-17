using XML130.Libraries;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XML130.Libraries
{
    public class EasyEncoding
    {
        public const string INIT_VECTOR_ENCRYPT_DECRYPT = "fruitytuanpn@gmailcom";

        public static string Encrypt(string plainText, string pass)
        {
            string initVector = "fruitytuanpn@gmail.com";
            return new RijndaelEnhanced(pass, initVector).Encrypt(plainText);
        }

        public static string Descrypt(string cipherText, string pass)
        {
            string initVector = "fruitytuanpn@gmailcom";
            return new RijndaelEnhanced(pass, initVector).Decrypt(cipherText);
        }

        public static bool EncryptFile(string pathFile, string pass)
        {
            string initVector = "fruitytuanpn@gmailcom";
            RijndaelEnhanced rijndaelEnhanced = new RijndaelEnhanced(pass, initVector);
            if (!File.Exists(pathFile))
                return false;
            try
            {
                byte[] plainTextBytes = File.ReadAllBytes(pathFile);
                byte[] bytes = rijndaelEnhanced.EncryptToBytes(plainTextBytes);
                File.WriteAllBytes(pathFile, bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public static bool DescryptFile(string pathFile, string pass, out MemoryStream stream)
        {
            string initVector = "fruitytuanpn@gmailcom";
            RijndaelEnhanced rijndaelEnhanced = new RijndaelEnhanced(pass, initVector);
            if (!File.Exists(pathFile))
            {
                stream = (MemoryStream)null;
                return false;
            }
            try
            {
                byte[] cipherTextBytes = File.ReadAllBytes(pathFile);
                byte[] bytes = rijndaelEnhanced.DecryptToBytes(cipherTextBytes);
                stream = new MemoryStream(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                stream = (MemoryStream)null;
                return false;
            }
            return true;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public class SHA1MD5
        {
            public static string SHA1Encoding(string Data) => Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(Data)));

            public static string MD5Encoding(string Data) => Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(Data)));
        }
    }
}
