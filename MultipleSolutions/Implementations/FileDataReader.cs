using MultipleSolutions.Interfaces;

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
