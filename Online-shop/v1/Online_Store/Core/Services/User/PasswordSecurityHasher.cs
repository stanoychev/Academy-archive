﻿using System;
using System.Security.Cryptography;

namespace Online_Store.Core.Services.User
{
    public class PasswordSecurityHasher : IPasswordSecurityHasher
    {
        private const int SaltSize = 16;

        private const int HashSize = 20;


        public string Hash(string password, int iterations)
        {
            //create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            //create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);   

            //combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            //convert to base64 in order to store
            var base64Hash = Convert.ToBase64String(hashBytes);

            //format hash with extra information
            return string.Format("$$DoNeVsKiHASH$V1${0}${1}", iterations, base64Hash);
        }

        //default param
        public string Hash(string password)
        {
            return Hash(password, 10000);
        }

        // checks for personaly encrypted sign
        public bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$DoNeVsKiHASH$V1$");
        }


        public bool Verify(string enteredPassword, string userPassword)
        {
            //Part 1: Make realPassword base 64
            //check the type of user password hash
            if (!IsHashSupported(userPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            //extracts iterations and base42 string
            var splittedHashString = userPassword.Replace("$$DoNeVsKiHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            //get hashbytes
            var hashBytes = Convert.FromBase64String(base64Hash);


            // Part 2: generate the same hash function
            //get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize); // (first array, startIndex, arrayBeingFilledWith first array, startIndexToBefilled, size of second array)

            //create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            //get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
