using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Web;

namespace Inventory
{
    public class DataManager
    {
        public string[] HashPassword(string _password)
        {
            //pass_hash[0]=password hashed, pass_hash[1]=hash key
            string[] pass_hash = new string[2];

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            pass_hash[0] = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: _password, 
                salt: salt, 
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));

            pass_hash[1] = Convert.ToBase64String(salt);
            

            return pass_hash;
        }

       
    }


}