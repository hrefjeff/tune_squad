using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LIFES.Authentication
{
    /*
     * Class Name: Encryption.cs
     * Created By: Scott Smoke
     * Date: 4/14/2015
     * Modified By: Scott Smoke
     * 
     * Description: This handles the encryption and decryption for the userlist class.
     * 
     */ 
    static class Encryption
    {
        private static string key = "abdelc;seopedladjcledoskedcoedmo";
        private static string iv = "aweopdklawmfovno";
         /*
         * Method: Encrypt
         * Parameters: string str
         * Created By: Scott Smoke
         * Date: 4/14/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will use AES encryption and encrypt a string.
         * 
         * Sources: 
         *       https://www.youtube.com/watch?v=UBoGknuv7ik
         *       https://msdn.microsoft.com/en-us/library/system.security.cryptography.aescryptoserviceprovider(v=vs.110).aspx
         * 
         */
        private static string Encrypt(string str)
        {
            
            byte[] plaintextbytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //iv block size 128 bit
            aes.BlockSize = 128;
            // key size 256 bit
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0
                , plaintextbytes.Length);
            return Convert.ToBase64String(encrypted);



        }
        /*
         * Method: Decrypt
         * Parameters: string str
         * Created By: Scott Smoke
         * Date: 4/14/2015
         * Modified By: Scott Smoke
         * 
         * Description: This will use AES encryption and decrypt a string.
         * 
         * Sources: 
         *       https://www.youtube.com/watch?v=UBoGknuv7ik
         *       https://msdn.microsoft.com/en-us/library/system.security.cryptography.aescryptoserviceprovider(v=vs.110).aspx
         * 
         */
        private static string Decrypt(string str)
        {
            byte[] encryptedBytes = Convert.FromBase64String(str);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //iv block size 128 bit
            aes.BlockSize = 128;
            // key size 256 bit
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] decrypted = crypto.TransformFinalBlock(encryptedBytes, 0
                , encryptedBytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(decrypted);
        }
        
    }
    }
}
