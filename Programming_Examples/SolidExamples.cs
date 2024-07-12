namespace Programming_Examples
{
    internal class SolidExamples
    {
        #region Single Responsibility Principle (SRP)
        //1- Single Responsibility Principle (SRP)
        /*
           The Single Responsibility Principle (SRP) states that a class should have only one reason to change. This means a class should only have one job or responsibility.
         */


        //the Patient class is only responsible for managing patient details
        public class Patient
        {
            public required string Name { get; set; }
            public required string Address { get; set; }

            public static void SavePatientDetails()
            {
                // Code to save patient details into database
            }
        }

        //and the InsuranceCalculator class is only responsible for calculating the insurance amount.
        public class InsuranceCalculator
        {
            public static decimal CalculateInsuranceAmount(Patient patient)
            {
                // Code to calculate insurance amount
                return 0;
            }
        }

        #endregion

        #region Open-Closed Principle (OCP) 

        //2- The Open-Closed Principle (OCP) 

        //The Open-Closed Principle (OCP) states that software entities (classes, modules, functions, etc.) should be open for extension but closed for modification.

        //each HealthInsurance subclass is responsible for calculating its own premium.

        public abstract class HealthInsurance
        {
            public decimal BasePremium { get; set; }

            public abstract decimal CalculatePremium();
        }

        public class StandardHealthInsurance : HealthInsurance
        {
            public override decimal CalculatePremium()
            {
                return BasePremium;
            }
        }

        public class SeniorCitizenHealthInsurance : HealthInsurance
        {
            public override decimal CalculatePremium()
            {
                return BasePremium * 1.2m;
            }
        }

        // If we want to add a new type of insurance, we can do so by creating a new subclass of HealthInsurance, without modifying any existing code. This adheres to the OCP.


        public class PremiumCalculator
        {
            public decimal CalculatePremium(HealthInsurance insurance)
            {
                return insurance.CalculatePremium();
            }
        }

        #endregion

        #region Liskov Substitution Principle (LSP)

        //3- Liskov Substitution Principle (LSP)

        // The Liskov Substitution Principle (LSP) states that "if a program is using a base class, then the reference to the base class can be replaced with a derived class without affecting the functionality of the program." In other words, every derived class should be substitutable for their base class without the client knowing or affecting the correctness of the program.

        public abstract class HealthInsuranceClaim
        {
            public abstract void ValidateClaim();
        }

        public class InpatientClaim : HealthInsuranceClaim
        {
            public override void ValidateClaim()
            {
                // Validate inpatient claim
            }
        }

        public class OutpatientClaim : HealthInsuranceClaim
        {
            public override void ValidateClaim()
            {
                // Validate outpatient claim
            }
        }

        // InpatientClaim and OutpatientClaim are subclasses of HealthInsuranceClaim.According to Liskov's Substitution Principle, we should be able to use an instance of the InpatientClaim or OutpatientClaim wherever you expect an instance of HealthInsuranceClaim, like so:

        public class ClaimProcessor
        {
            public void ProcessClaim(HealthInsuranceClaim claim)
            {
                claim.ValidateClaim();
                // Process the claim
            }
        }

        #endregion

        #region Interface Segregation Principle (ISP)

        //4- Interface Segregation Principle (ISP)

        //The Interface Segregation Principle(ISP) states that "clients should not be forced to depend on interfaces they do not use." In other words, it's better to have many smaller, specific interfaces than one large, general interface.

        public interface IHealthcareProvider
        {
            void PerformSurgery();
            void ProvidePrimaryCare();
            void ProvideEmergencyCare();
        }

        //Not all healthcare providers offer all these services. For example, a General Practitioner might only provide primary care, not surgeries or emergency care. This violates the ISP.

        // Here's how we can refactor this to adhere to the ISP:

        public interface ISurgeon
        {
            void PerformSurgery();
        }

        public interface IPrimaryCareProvider
        {
            void ProvidePrimaryCare();
        }

        public interface IEmergencyCareProvider
        {
            void ProvideEmergencyCare();
        }

        //Now, healthcare providers can implement only the interfaces for the services they actually provide:

        public class GeneralPractitioner : IPrimaryCareProvider
        {
            public void ProvidePrimaryCare()
            {
                // Provide primary care
            }
        }

        public class Surgeon : ISurgeon
        {
            public void PerformSurgery()
            {
                // Perform surgery
            }
        }

        public class EmergencyDoctor : IPrimaryCareProvider, IEmergencyCareProvider
        {
            public void ProvidePrimaryCare()
            {
                // Provide primary care
            }

            public void ProvideEmergencyCare()
            {
                // Provide emergency care
            }
        }

        //This adheres to the Interface Segregation Principle because clients of these classes are not forced to depend on methods they do not use.

        #endregion

        #region Dependency Inversion Principle (DIP)

        //5- Dependency Inversion Principle (DIP)

        //The Dependency Inversion Principle (DIP) is the last principle of SOLID and it states that:

        //High-level modules should not depend on low-level modules.Both should depend on abstractions.

        //Abstractions should not depend on details. Details should depend on abstractions.

        //In simple terms, it promotes the use of interfaces or abstract classes to decouple the high-level and low-level modules of an application.

        //A naive approach might directly instantiate a PremiumCalculator inside the InsurancePolicy class:

        public class InsurancePremiumCalculator
        {
            public decimal CalculateInsurancePremium(InsurancePolicy policy)
            {
                // Calculate premium
                return 0;
            }
        }

        public class InsurancePolicy
        {
            public decimal CalculatePolicyPremium()
            {
                var calculator = new InsurancePremiumCalculator();
                return calculator.CalculateInsurancePremium(this);
            }
        }

        //In this example, InsurancePolicy is tightly coupled to PremiumCalculator. This violates the DIP.

        //we can refactor this to adhere to the DIP:

        public interface IPremiumInsCalculator
        {
            decimal CalculatePremium(InsuranceInsPolicy policy);
        }

        public class PremiumInsCalculator : IPremiumInsCalculator
        {
            public decimal CalculatePremium(InsuranceInsPolicy policy)
            {
                // Calculate premium
                return 0;
            }
        }

        public class InsuranceInsPolicy(SolidExamples.IPremiumInsCalculator premiumCalculator)
        {
            private readonly IPremiumInsCalculator _premiumCalculator = premiumCalculator;

            public decimal CalculatePolicyPremium()
            {
                return _premiumCalculator.CalculatePremium(this);
            }
        }

        #endregion

    }
}
