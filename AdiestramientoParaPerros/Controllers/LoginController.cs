using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Controllers
{
    public class LoginController : Controller
    {
        #region Controlador Vista LoginIndex
        public IActionResult LoginIndex()
        {

            return View();
        }


        [HttpPost]
        public IActionResult LoginIndex(String email, String password)
        {
            //LLamar a la BBDD 
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            String savedPasswordHash = Convert.ToBase64String(hashBytes);
            //Ahora añadiria a la bdd el savedpasswordhash

            //savedPasswordHash se recupera de la bdd
            String savedPasswordHash2 = savedPasswordHash;

            byte[] hashbytes2 = Convert.FromBase64String(savedPasswordHash2);

            byte[] salt2 = new byte[16];
            Array.Copy(hashbytes2, 0, salt, 0, 16);

            var pbkdf22 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash2 = pbkdf22.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashbytes2[i + 16] != hash2[i])
                    throw new UnauthorizedAccessException();


            return View();
        }
        #endregion

        #region Controlador Vista SignUp
        public IActionResult SignUp()
        {
            return View();
        }
        #endregion
    }
}
