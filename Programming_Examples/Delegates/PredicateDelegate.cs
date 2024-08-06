using Programming_Examples.Models;

namespace Programming_Examples.Delegates
{
    public static class PredicateDelegate
    {
        public static void FilteringPolicyholders()
        {
            // List of policyholders
            List<Policyholder> policyholders =
                                            [
                                                new Policyholder { Name = "Example One", InsuranceType = "Health" },
                                                new Policyholder { Name = "Example Two", InsuranceType = "Life" },
                                                new Policyholder { Name = "Example Three", InsuranceType = "Health" },
                                                new Policyholder { Name = "Example Four", InsuranceType = "Auto" }
                                            ];

            // Create a Predicate delegate instance
            Predicate<Policyholder> healthInsurancePredicate = IsHealthInsurance;

            // Find all policyholders with health insurance
            List<Policyholder> healthPolicyholders = policyholders.FindAll(healthInsurancePredicate);

            // Output the filtered list
            Console.WriteLine("Policyholders with health insurance:");
            foreach (var policyholder in healthPolicyholders)
            {
                Console.WriteLine(policyholder.Name);
            }
        }
        private static bool IsHealthInsurance(Policyholder policyholder)
        {
            return policyholder.InsuranceType == "Health";
        }
    }
}
