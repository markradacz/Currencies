using Newtonsoft.Json;
using System.IO;

namespace Currencies
{
    public class Json
    {
        public static T Deserialize<T>(string path)
            => JsonConvert.DeserializeObject<T>(File.ReadAllText(path));

        public static dynamic Deserialize(string data)
            => JsonConvert.DeserializeObject(data);
    }
}
