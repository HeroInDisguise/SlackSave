using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools
{
    class JsonSerializer
    {
        public static string SerializeJson<T>(T obj, TypeNameHandling typeNameHandling) where T : class, new()
        {
            var setting = new JsonSerializerSettings();
            setting.TypeNameHandling = typeNameHandling;
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var jsonString = JsonConvert.SerializeObject(value: obj, settings: setting);

            //Funktionswert
            return jsonString;
        }

        public static string SerializeJson<T>(T obj) where T : class, new()
        {
            var jsonString = SerializeJson<T>(obj: obj, typeNameHandling: TypeNameHandling.All);
            //Funktionswert
            return jsonString;
        }

        public static T DeserializeJson<T>(string jsonString) where T : class, new()
        {
            var result = default(T);

            var setting = new JsonSerializerSettings();
            setting.TypeNameHandling = TypeNameHandling.All;

            if (string.IsNullOrWhiteSpace(jsonString) == false)
            {

                result = JsonConvert.DeserializeObject<T>(jsonString, setting);

            }

            //Funktionswert
            return result;
        }
    }
}
