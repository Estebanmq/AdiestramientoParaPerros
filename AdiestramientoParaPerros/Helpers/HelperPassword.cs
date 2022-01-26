using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Helpers
{
    public static class HelperPassword
    {

        /// <summary>
        ///     Hashea la contraseña deseada
        /// </summary>
        /// <param name="password">
        ///     La contraseña que se quiere hashear
        /// </param>
        /// <returns>
        ///     La contraseña hasheada
        /// </returns>
        public static byte[] GetHashedPassword(String password)
        {
            //El salt son bits aleatorios que se utilizan para encriptar cosas, en este caso la contraseña
            byte[] salt;
            //Esta clase genera aleatorios, en este caso bytes
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //Este variable pbkdf2 es para encriptar la contraseña con el salt indicando el numero de iteraciones
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            //Guardo el hash anterior en un array de bytes 
            byte[] hash = pbkdf2.GetBytes(20);

            //hashbytes almacena el salt y el hash de la contraseña
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //Insertaria esto en la bbdd, retorna el string del hasheo final
            return hashBytes;
        } 

        /// <summary>
        ///     Compara el hash de una contraseña con la contraseña
        /// </summary>
        /// <param name="hashedPassword">
        ///     Contraseña hasheada
        /// </param>
        /// <param name="password">
        ///     Contraseña a comparar
        /// </param>
        /// <returns>
        ///     True en el caso de que la contraseña y el hash sea igual
        ///     False en el caso contrario
        /// </returns>
        public static bool CompareHashPassword(byte[] hashedPassword, String password)
        {
            //hashedPassword viene de la bbdd

            //Hashbytes almacena el hash en bytes[] de una contraseña retornada del metodo GetHashedPassword
            byte[] hashbytes = hashedPassword;

            //Me creo un salt igual que en GetHashedPassword
            byte[] salt = new byte[16];
            //Copio hashbytes al array de salt
            Array.Copy(hashbytes, 0, salt, 0, 16);

            //Este variable pbkdf2 es para encriptar la contraseña con el salt indicando el numero de iteraciones
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            //Guardo en bytes[] el hash
            byte[] hash = pbkdf2.GetBytes(20);
            //COmparo byte por byte y si es distinto en algun momento no es la misma contraseña
            for (int i = 0; i < 20; i++)
                if (hashbytes[i + 16] != hash[i])
                    return false;
            return true;
        }

    }
}
