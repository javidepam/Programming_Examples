using MultipleSolutions.Implementations;
using MultipleSolutions.Interfaces;
using MultipleSolutions.Models;

namespace MultipleSolutions.Handlers
{
    public class DuplicateIdentifier(
        IDataReaderFile dataReader,
        IDataParser<Person> dataParser,
        IDuplicateFinder<Person, int> duplicateFinder)
    {
        public void GetDuplicateItems()
        {
            string filePath = "DemoData/QualifiersList.json";

            try
            {
                string jsonString = dataReader.ReadData(filePath);
                List<Person> people = dataParser.ParseData(jsonString);
                Dictionary<Person, int> duplicates = duplicateFinder.FindDuplicates(people);

                var personIterator = new PersonIterator(duplicates);
                ShowResults(personIterator);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void ShowResults(PersonIterator personIterator)
        {
            const int columnWidthFirstName = 15;
            const int columnWidthLastName = 15;
            const int columnWidthCount = 5;

            Console.WriteLine("The list of the duplicate users are as:");

            // Print header
            Console.WriteLine($"| {"First Name",-columnWidthFirstName} | {"Last Name",-columnWidthLastName} | {"Count",columnWidthCount} |");
            Console.WriteLine(new string('-', columnWidthFirstName + columnWidthLastName + columnWidthCount + 11));

            // Print records
            foreach (var entry in personIterator)
            {
                Console.WriteLine($"| {entry.Key.FirstName,-columnWidthFirstName} | {entry.Key.LastName,-columnWidthLastName} | {entry.Value,columnWidthCount} |");
                Console.WriteLine(new string('-', columnWidthFirstName + columnWidthLastName + columnWidthCount + 11));
            }
        }
    }

}
