// See https://aka.ms/new-console-template for more information
using Programming_Examples;
using static Programming_Examples.SolvingProblems;

internal class Program
{
    public delegate int CalculateDelegate(int i);
    public static CalculateDelegate cd = null;

    private static void Main(string[] args)
    {
        //PrintClassTypeTable.PrintClassType();

        DelegateSection.DelegateFunc();
    }
}