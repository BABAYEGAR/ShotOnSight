﻿using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ShotOnSight.Models.Encryption
{
    public class Md5Ecryption
    {
        /// <summary>
        ///     This method converts a string to a MD5 hash algorith, string
        /// </summary>
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        public string ConvertStringToMd5Hash(string originalPassword)
        {
            return string.Join("",
                MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(originalPassword)).Select(s => s.ToString("x2")));
        }
    }
}