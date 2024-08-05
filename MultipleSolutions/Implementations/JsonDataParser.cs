using MultipleSolutions.Interfaces;
using System.Text.Json;

namespace MultipleSolutions.Implementations
{
    public class JsonDataParser<T> : IDataParser<T>
    {
        public List<T> ParseData(string data)
        {
            return JsonSerializer.Deserialize<List<T>>(data) ?? new List<T>();
        }
    }
}
