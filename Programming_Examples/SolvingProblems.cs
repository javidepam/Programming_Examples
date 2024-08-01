using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Programming_Examples
{

    public static class SolvingProblems
    {

        public static void GetList()
        {
            string filePath = "QualifiersList.json";

            try
            {
                // Read the JSON file content
                string jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string to a list of Person objects
                List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonString ?? null);

                // Identify and print duplicate users
                var duplicates = FindDuplicates(people);

                Console.WriteLine("Duplicate users:");
                foreach (var person in duplicates)
                {
                    Console.WriteLine($"First Name: {person.FirstName}, Last Name: {person.LastName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public static List<Person> FindDuplicates(List<Person> people)
        {
            // Group people by FirstName and LastName and find groups with more than one item
            var duplicates = people
                .GroupBy(p => new { p.FirstName, p.LastName })
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .Distinct()
                .ToList();

            return duplicates;
        }
    }
}
