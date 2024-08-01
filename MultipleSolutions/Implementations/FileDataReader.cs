using MultipleSolutions.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSolutions.Implementations
{
    public class FileDataReader : IDataReaderFile
    {
        public string ReadData(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
