using MultipleSolutions.Interfaces;
using MultipleSolutions.Models;

namespace MultipleSolutions.Implementations
{
    public class PersonDuplicateFinder : IDuplicateFinder<Person, int>
    {
        public Dictionary<Person, int> FindDuplicates(List<Person> people)
        {
            var countDictionary = new Dictionary<Person, int>(new PersonEqualityComparer());

            // Count occurrences of each person
            foreach (var person in people)
            {
                if (countDictionary.TryGetValue(person, out int value))
                {
                    countDictionary[person] = ++value;
                }
                else
                {
                    countDictionary[person] = 1;
                }
            }

            // Filter out items that have more than one occurrence
            var duplicates = countDictionary.Where(pair => pair.Value > 1)
                                            .ToDictionary(pair => pair.Key, pair => pair.Value);

            return duplicates;
        }
    }



    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (x == null || y == null)
                return false;

            return x?.FirstName == y?.FirstName && x?.LastName == y?.LastName;
        }

        public int GetHashCode(Person? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            // Combine the hash codes of FirstName and LastName
            int hashFirstName = obj?.FirstName == null ? 0 : obj.FirstName.GetHashCode();
            int hashLastName = obj?.LastName == null ? 0 : obj.LastName.GetHashCode();

            return hashFirstName ^ hashLastName; // XOR to combine hash codes
        }
    }
}
