namespace MultipleSolutions.Interfaces
{
    public interface IDuplicateFinder<T, U>
    {
        Dictionary<T, U> FindDuplicates(List<T> items);
    }
}
