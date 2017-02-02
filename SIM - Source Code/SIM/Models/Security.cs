/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SIM.Models
{
    public class Security
    {
        private static string Key = "SimpleInstituteManagementSystem.";
        private static string IV = "SIMApplicationJK";
        private static string Salt = "$1M";

        public static string Encrypt(string text)
        {
            try
            {
                //byte[] encryptedText;
                //byte[] plainText = ASCIIEncoding.ASCII.GetBytes(text);
                //AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                //aes.BlockSize = 128;
                //aes.KeySize = 256;
                //aes.Key = ASCIIEncoding.ASCII.GetBytes(Key);
                //aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                //aes.Padding = PaddingMode.PKCS7;
                //aes.Mode = CipherMode.CBC;
                //ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
                //encryptedText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
                //crypto.Dispose();
                //return Convert.ToBase64String(encryptedText);

                return Convert.ToBase64String(Encoding.ASCII.GetBytes(text + Salt));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Decrypt(string text)
        {
            try
            {
                //byte[] decryptedText;
                //byte[] plainText = Convert.FromBase64String(text);
                //AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                //aes.BlockSize = 128;
                //aes.KeySize = 256;
                //aes.Key = ASCIIEncoding.ASCII.GetBytes(Key);
                //aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                //aes.Padding = PaddingMode.PKCS7;
                //aes.Mode = CipherMode.CBC;
                //ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
                //decryptedText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
                //crypto.Dispose();
                //return ASCIIEncoding.ASCII.GetString(decryptedText);

                return Encoding.ASCII.GetString(Convert.FromBase64String(text)).Replace(Salt, string.Empty);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool IsSessionExist()
        {
            bool flag = false;

            try
            {
                int? count = Convert.ToInt32(HttpContext.Current.Session.Count);

                if (count != null)
                {
                    if (count == 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return flag;
        }
    }
}