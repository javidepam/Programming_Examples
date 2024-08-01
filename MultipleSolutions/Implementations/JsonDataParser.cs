using MultipleSolutions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
