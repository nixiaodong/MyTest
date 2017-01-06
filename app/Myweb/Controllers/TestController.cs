using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using textdall;

namespace Myweb.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            String key = "abcdefghijklmno2";
            CryptoHelper helper = new CryptoHelper(key);
            String encryptedText = "/enPzkAZio4vafp5ctvhjDbLW2b4XmzXDlhB2u/0SmDRk6Weq9SSxjulMSJWMwv8fHgQkMmZzR1NPuJRN7U2eU1BvCr+MCVHNXQ46GrB4Kpxv5abG1uXfoXREaABGfjR72qUzmp3KJZBSiW//eLoSRKYDJbUaedgMUEsvBH4fSfCOx+nQ9Eh03Kp0FswJsEAliqcoglsw/nbxiFq5UVDzmLKQikJJ51xGx/eXezUQ+ezqWsg5rDuNrouf2JTTZKs8SUiApYZDpaQLq4/E4lCeQkwVT9KlCPXwr7bQa2DJpfDA2qUdPn+Rw1XvHO0Fw4aQfJ207WzqkLLmn4yHmaYs8XvoYbPymkF84u//0U3Ll9R43j0k3UWw94+NP2MYn5FXp6xhdHe77IU5PWjEkiyGYKtgg4MF+h6T93I6L25zhiQeqCIYV1KvWNf5dZIytRR2UfzOKkt6yMDG3mRhdU3bFDycIekr2Pg8+4wUpieZfN1A5Th6epYSwx5d2QzJq/5LtmOeBay/2dJNvlEYuKb5pu17bWrhm6XBnY1Hn9DgYyfAdu1e3EFrcoQ+M3PL4osgFuhbVNdAWvnXJmzXT9jlI58t139TE973D1od38VV8DqT3n8p0jYm2l6dSQtfFGroK+99pBgvSTHatAwmsUbAWe01FThsIQqke4TVmshrMDKIUAAwxvwQeKOEFLakTdWpFWzot7Hd0pxfsnCndHjJz8rWNSyPWUlQTdoxPZk2PQYNfNecgT3SBvRk1Rm0KzCQtq/xx8fNRHY79KcwXh0yTYXyG4BgQhvdNERIOzv7QwUvUiGgEzSs+M24xN5bspU5Vis7DhxR+Xy+GpUpDvetowHaj5VwxCJ5G5TPRIKvabvSNdNUVIvnOpqTYDKHaXFcZDoHZpJPJk+cHEucoo5RYX9aE4zr1X+fc1Oi3r4eE2N7ab4RA+n2s84eCKPcFYxiaXULi5kL1bGpvQ7v6CrbTxkw8/mNNcDFyhExMkLDtYR4SJ1Y7SG/QQ/sD84cQE/bGrgKRyym1GOzeNxoHZePPKK4WkzUbrn8QKbHIBi5cKU5XhLemhDGESNN0ym+SekZ0bqHxXMkXc+1jEDHFx3vdZfhnlks/pHzMqMA2TQWFAgbaNaIJ3ihrWAUlMxIqEUoK7hl9n6WN5SwObz/Ax2tURDV1YyOZZTwYsL+hl7v4vDcwcEGI3EtKwhTEfMXfwGKtwFSDZDU2NxkotTP/EFkFM5czJwzjTADrZorf4WEdZinpQQKxoXTklvdF5PP4Hp4ZedlMT0iLbTMWQoh27Ks6ImzwKz/pLwuFdF3EKx8u2+zEbbSonlT3YMa+hDXSsVyLT5QFiGQjvX7SyvkeHwgCcOMjKBDvCf";

            String DecryptText = helper.Decrypt(encryptedText);
            ViewBag.Decrypt = DecryptText;
            String encrypted = "Nq66uW3Bdv6K99/DMiolQeOxGkAQPvlA34GSsDCL7oX8wxzFJTfrj2iLs46IEgQjb4BnFX5oEg9pk+ujb3368H9KyAyfeKBTvIK9twtuZb83D1K23X3mOq+jX4RuOUT+aiyHYPkEMttbh2QwLiZEZ8B5Hxq+AL6afhLG9k7oj48=";
            ViewBag.decrypted = RSAHelper.Decrypt(encrypted);
            return View();
        }
        /// <summary>
        /// 目录树
        /// </summary>
        /// <returns></returns>
        public ActionResult DirectoryTree()
        {
            //String key = "ABCDEFGHIJKLMNOP";
            //String key = "ABCDEFGHIYKLMNOP";
            //String key = "PAIISIDNHYSBGGSB";
            String key = "abcdefghijklmno2";//17位数
            String clearText = "欢迎光临!www.ritztours.com";

            CryptoHelper helper = new CryptoHelper(key);

            String encryptedText = helper.Encrypt(clearText);
            String DecryptText = helper.Decrypt(encryptedText);
            ViewBag.encrypted = encryptedText;
            ViewBag.Decrypt = DecryptText;
            String text = "欢迎光临!www.ritztours.com &&　成功了";
            String Encryptoed = RSAHelper.Encrypt(text);

            String Decryptoed = RSAHelper.Decrypt(Encryptoed);
            ViewBag.encrypoed = Encryptoed;
            ViewBag.decryptoed = Decryptoed;
            return View();
        }
        /// <summary>
        /// 自定义双向绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult JqIndex()
        {
            return View();
        }
        #region 二维码
        public ActionResult ErwmIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="strData">要生成的文字或者数字，支持中文</param>
        /// <param name="qrEncoding">三种尺寸：BYTE ，ALPHA_NUMERIC，NUMERIC</param>
        /// <param name="level">大小：L M Q H</param>
        /// <param name="version">版本：如 8</param>
        /// <param name="scale">比例：如 4</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateErwm(String strData, String qrEncoding, String level, Int32 version, Int32 scale)
        {
            String path = Server.MapPath(@"~\Upload");
            String ImgPath = Server.MapPath(@"~\Images");
            String filename = ErwmHelper.CreateCode_Choose(strData, qrEncoding, level, version, scale, path, ImgPath);

            return Content(@"/Upload/" + filename);
        }

        public String CodeDecoder(String filePath)
        {
            var nowUri = Server.MapPath(@filePath); ;
            return ErwmHelper.CodeDecoder(nowUri);
        }
        #endregion

        /// <summary>
        /// 读取Excel表格
        /// </summary>
        /// <returns></returns>
        public ActionResult ReadExcel()
        {
            ViewBag.Title = "";
            String FilePath = Server.MapPath(@"~\Upload") + "\\" + "test.xlsx";
            ViewBag.DataSets = ReadExcelHelper.ReadExcel(FilePath);
            return View();
        }

        public ActionResult Pdf2Word()
        {
            String FilePath = Server.MapPath(@"~\Upload") + "\\" + "testpdf.pdf";
            new Pdf2WordHelper().transfer2Pdf(FilePath);
            return View();
        }
    }
}