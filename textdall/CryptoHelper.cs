using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace textdall
{
    /// <summary>
    /// 对称加密帮助类
    /// </summary>
    public class CryptoHelper
    {
        // 对称加密算法提供器
        private ICryptoTransform encryptor;//加密器对象
        private ICryptoTransform decryptor;//解密器对象
        private const int BufferSize = 1024;

        public CryptoHelper(String algorithmName, String key)
        {
            SymmetricAlgorithm provider = SymmetricAlgorithm.Create(algorithmName);
            provider.Key = Encoding.UTF8.GetBytes(key);//加密密钥
            //provider.IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };//偏移量
            provider.IV = new byte[] { 0x12, 0x34, 0x06, 0x11, 0x90, 0x21, 0x12, 0x10 };

            encryptor = provider.CreateEncryptor();
            decryptor = provider.CreateDecryptor();
        }
        /// <summary>
        ///  TripleDES 算法 给密钥加密
        /// </summary>
        /// <param name="key"></param>
        public CryptoHelper(string key) : this("TripleDES", key) { }

        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public String Encrypt(String clearText)
        {

            //创建明文流
            byte[] clearBuffer = Encoding.UTF8.GetBytes(clearText);
            MemoryStream clearStream = new MemoryStream(clearBuffer);

            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write);

            //将明文流写入到buffer中
            //将buffer中的数据写入到cryptoStream 中

            int bytesRead = 0;
            byte[] buffer = new byte[BufferSize];
            //不能用循环 会执行两次
            //do
            //{
                bytesRead = clearStream.Read(buffer, 0, BufferSize);
                cryptoStream.Write(buffer, 0, BufferSize);
            //} while (bytesRead > 0);

            cryptoStream.FlushFinalBlock();

            //获取加密后的文本
            buffer = encryptedStream.ToArray();
            string encryptedText = Convert.ToBase64String(buffer);

            return encryptedText;
        }
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public String Decrypt(String encryptedText)
        {

            byte[] encryptedBuffer = Convert.FromBase64String(encryptedText);
            Stream encryptedStream = new MemoryStream(encryptedBuffer);

            MemoryStream clearStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(encryptedStream, decryptor, CryptoStreamMode.Read);

            int bytesRead = 0;
            byte[] buffer = new byte[BufferSize];
            //不能用循环 会执行两次
            //do
            //{
                bytesRead = cryptoStream.Read(buffer, 0, BufferSize);
                clearStream.Write(buffer, 0, bytesRead);
            //} while (bytesRead > 0);


            buffer = clearStream.GetBuffer();
            String clearText = Encoding.UTF8.GetString(buffer, 0, (int)clearStream.Length);

            return clearText;
        }

        public static String Encrypt(String clearText, string Key)
        {
            CryptoHelper helper = new CryptoHelper(Key);
            return helper.Encrypt(clearText);
        }


        public static String Decrypt(String encryptedText, String Key)
        {
            CryptoHelper helper = new CryptoHelper(Key);
            return helper.Decrypt(encryptedText);
        }
    }
}
