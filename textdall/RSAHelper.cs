using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace textdall
{
    public class RSAHelper
    {
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public static String Encrypt(String algorithmName)
        {
            int rsa = 1;
            CspParameters cspParms = new CspParameters(rsa);
            cspParms.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParms.KeyContainerName = "ASSCSSSS";
            RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider(cspParms);
            byte[] sourceBytes = new UnicodeEncoding().GetBytes(algorithmName);
            byte[] rasCipherText = algorithm.Encrypt(sourceBytes, true);
            return Convert.ToBase64String(rasCipherText);
        }
        /// <summary>
        /// RSA开始解密
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public static String Decrypt(String encryptedText)
        {
            var rsa = 1;
            // decrypt the data.
            byte[] encryptedBuffer = Convert.FromBase64String(encryptedText);
            var cspParms = new CspParameters(rsa);
            cspParms.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParms.KeyContainerName = "ASSCSSSS";
            RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider(cspParms);
            byte[] unencrypted = algorithm.Decrypt(encryptedBuffer, true);
            String Decrytoed = new UnicodeEncoding().GetString(unencrypted);
            return Decrytoed;
        }

    }
}
