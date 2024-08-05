namespace MultipleSolutions.Interfaces
{
    public interface IDataParser<T>
    {
        List<T> ParseData(string data);
    }
}
