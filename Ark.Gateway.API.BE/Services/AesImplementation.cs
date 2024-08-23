using System.Security.Cryptography;
using System.Text;

namespace Ark.Gateway.API.BE.Services
{
    public class AesImplementation : IAESEnc
    {

        private readonly string? usdkey;
        private readonly string? rtgskey;

        public AesImplementation(IConfiguration configuration)
        {
            usdkey = configuration["USDcode"];
            rtgskey = configuration["RTGScode"];
        }

        public string USDEncrypt(string text)
        {
            var _USDkey = usdkey;
            var _USDinitVector = usdkey[..16];
            var aes = Aes.Create("AesManaged");
            aes.Key = Encoding.UTF8.GetBytes(_USDkey);
            aes.IV = Encoding.UTF8.GetBytes(_USDinitVector);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = aes.CreateEncryptor();
            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
            using (StreamWriter sw = new(cs))
            {
                sw.Write(text);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public string RTGSEncrypt(string text)
        {
            var _RTGSkey = rtgskey;
            var _RTGSinitVector = rtgskey[..16];
            var aes = Aes.Create("AesManaged");
            aes.Key = Encoding.UTF8.GetBytes(_RTGSkey);
            aes.IV = Encoding.UTF8.GetBytes(_RTGSinitVector);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = aes.CreateEncryptor();
            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
            using (StreamWriter sw = new(cs))
            {
                sw.Write(text);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public string USDDecrypt(string text)
        {
            var _USDkey = usdkey;
            var _USDinitVector = usdkey[..16];
            var aes = Aes.Create("AesManaged");
            aes.Key = Encoding.UTF8.GetBytes(_USDkey);
            aes.IV = Encoding.UTF8.GetBytes(_USDinitVector);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = aes.CreateDecryptor();
            using MemoryStream ms = new(Convert.FromBase64String(text));
            using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
            using StreamReader reader = new(cs);
            return reader.ReadToEnd();
        }

        public string RTGSDecrypt(string text)
        {

            var _RTGSkey = rtgskey;
            var _RTGSinitVector = rtgskey[..16];
            var aes = Aes.Create("AesManaged");
            aes.Key = Encoding.UTF8.GetBytes(_RTGSkey);
            aes.IV = Encoding.UTF8.GetBytes(_RTGSinitVector);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = aes.CreateDecryptor();
            using MemoryStream ms = new(Convert.FromBase64String(text));
            using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
            using StreamReader reader = new(cs);
            var _data = reader.ReadToEnd();
            return _data;
        }

    }
}
