using Programming_Examples.Models;
using Programming_Examples.Services;
using Programming_Examples.Utility;

namespace Programming_Examples.Threading
{
    public class BasicThreadingExample(HealthcareService healthcareService)
    {
        private readonly HealthcareService _healthcareService = healthcareService;

        public void FetchPatientAndInsuranceDetails(int patientId)
        {
            Patient? patient = null;
            Insurance? insurance = null;

            Thread? patientThread = new(() =>
            {
                patient = _healthcareService.GetPatientById(patientId);
            });

            Thread? insuranceThread = new(() =>
            {
                insurance = _healthcareService.GetInsuranceByPatientId(patientId);
            });

            // Start the threads
            patientThread.Start();
            insuranceThread.Start();

            // Wait for both threads to complete
            patientThread.Join();
            insuranceThread.Join();

            bool isValidPatient = GenericValidator.Validate(patientThread);
            bool isValidInsurance = GenericValidator.Validate(insuranceThread);

            // Process the results
            if (isValidPatient && isValidInsurance)
            {
                Console.WriteLine($"Patient Name: {patient?.Name}, Insurance Company: {insurance?.InsuranceCompany}");
            }
            else
            {
                Console.WriteLine("Failed to fetch patient or insurance details.");
            }
        }

    }
}
