using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Examples
{
    public static class PrintClassTypeTable
    {
        public static void PrintClassType()
        {
            // Define the table structure
            string[] headers = ["Class Type", "", "Can inherit from others", "Can be inherited", "Can be instantiated"];
            string[,] rows = {
            { "normal", ":", "YES", "YES", "YES" },
            { "abstract", ":", "YES", "YES", "NO" },
            { "sealed", ":", "YES", "NO", "YES" },
            { "static", ":", "NO", "NO", "NO" },
            { "interface", ":", "NO", "YES", "NO" },
            { "partial", ":", "YES", "YES", "YES" },
        };

            // Define column widths
            int[] columnWidths = { 14, 3, 25, 18, 21 };

            // Print the top border
            PrintLine(columnWidths);

            // Print the headers
            PrintRow(headers, columnWidths);
            PrintLine(columnWidths);

            // Print the rows
            for (int i = 0; i < rows.GetLength(0); i++)
            {
                string[] row = new string[rows.GetLength(1)];
                for (int j = 0; j < rows.GetLength(1); j++)
                {
                    row[j] = rows[i, j];
                }
                PrintRow(row, columnWidths);
                PrintLine(columnWidths);
            }
        }

        public static void PrintLine(int[] columnWidths)
        {
            Console.Write("+");
            for (int i = 0; i < columnWidths.Length; i++)
            {
                Console.Write(new string('-', columnWidths[i]));
                Console.Write("+");
            }
            Console.WriteLine();
        }

        public static void PrintRow(string[] columns, int[] columnWidths)
        {
            Console.Write("|");
            for (int i = 0; i < columns.Length; i++)
            {
                Console.Write(" " + columns[i].PadRight(columnWidths[i] - 1));
                Console.Write("|");
            }
            Console.WriteLine();
        }
    }
}
