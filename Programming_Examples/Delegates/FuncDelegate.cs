namespace Programming_Examples.Delegates
{
    public static class FuncDelegate
    {
        public static void PremimumCheckUsingFunc()
        {
            // Define a Func delegate that matches the CalculatePremium method signature
            Func<int, string, double, double> premiumCalculator = CalculatePremium;

            // Example data
            int age = 55;
            string healthCondition = "poor";
            double coverageAmount = 100000;

            // Calculate the premium using the Func delegate
            double premium = premiumCalculator(age, healthCondition, coverageAmount);

            // Output the calculated premium
            Console.WriteLine($"The insurance premium for a {age}-year-old with {healthCondition} health condition and ${coverageAmount} coverage is: ${premium}");
        }
        // Define a method to calculate the premium
        private static double CalculatePremium(int age, string healthCondition, double coverageAmount)
        {
            double basePremium = coverageAmount * 0.05; // 5% of the coverage amount

            if (age > 50)
            {
                basePremium += coverageAmount * 0.02; // Additional 2% if age is over 50
            }

            if (healthCondition == "poor")
            {
                basePremium += coverageAmount * 0.03; // Additional 3% for poor health condition
            }

            return basePremium;
        }

    }
}
