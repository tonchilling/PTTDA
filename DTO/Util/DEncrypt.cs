﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace DTO.Util
{
   public class DEncrypt
    {


       public static string encrypt(string password, string key)
       {
           byte[] results;
           UTF8Encoding utf8 = new UTF8Encoding();
           //to create the object for UTF8Encoding  class
           //TO create the object for MD5CryptoServiceProvider
           MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
           byte[] deskey = md5.ComputeHash(utf8.GetBytes(key));
           //to convert to binary passkey
           //TO create the object for  TripleDESCryptoServiceProvider
           TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
           desalg.Key = deskey;//to  pass encode key
           desalg.Mode = CipherMode.ECB;
           desalg.Padding = PaddingMode.PKCS7;
           byte[] encrypt_data = utf8.GetBytes(password);
           //to convert the string to utf encoding binary

           try
           {

               //To transform the utf binary code to md5 encrypt
               ICryptoTransform encryptor = desalg.CreateEncryptor();
               results = encryptor.TransformFinalBlock(encrypt_data, 0, encrypt_data.Length);

           }
           finally
           {
               //to clear the allocated memory
               desalg.Clear();
               md5.Clear();
           }

           //to convert to 64 bit string from converted md5 algorithm binary code
           return Convert.ToBase64String(results);

       }





       public static string decrypt(string password, string key)
       {
           byte[] results;
           UTF8Encoding utf8 = new UTF8Encoding();
           MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
           byte[] deskey = md5.ComputeHash(utf8.GetBytes(key));
           TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
           desalg.Key = deskey;
           desalg.Mode = CipherMode.ECB;
           desalg.Padding = PaddingMode.PKCS7;
           byte[] decrypt_data = Convert.FromBase64String(password);
           try
           {
               //To transform the utf binary code to md5 decrypt
               ICryptoTransform decryptor = desalg.CreateDecryptor();
               results = decryptor.TransformFinalBlock(decrypt_data, 0, decrypt_data.Length);
           }
           finally
           {
               desalg.Clear();
               md5.Clear();

           }
           //TO convert decrypted binery code to string
           return utf8.GetString(results);
       }
    }
}
