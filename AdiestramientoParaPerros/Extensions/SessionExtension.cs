using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Extensions
{
    public static class SessionExtension
    {

        /// <summary>
        ///     Almacena un objeto con una key en session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">El key que va a tener el objeto</param>
        /// <param name="obj">El objeto que se quiere almacenar</param>
        public static void SetObject(this ISession session, String key, Object obj)
        {
            String data = JsonConvert.SerializeObject(obj);
            session.SetString(key, data);
        }

        /// <summary>
        ///     Devuelve un objeto almacenado en session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key">La key correspondiente al objeto</param>
        /// <returns> El objeto deserializado al que pertenece la key. default(T) si no lo encuentra.</returns>
        public static T GetObject<T>(this ISession session, String key)
        {
            String data = session.GetString(key);
            if(data == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }
    }
}
