using Programming_Examples.Services;
using Programming_Examples.Utility;

namespace Programming_Examples.TPL
{
    public class TPLExample(HealthcareService healthcareService)
    {
        public async Task FetchPatientAndInsuranceDetailsAsync(int patientId)
        {
            // Create tasks for fetching patient and insurance details
            var patientTask = Task.Run(() => healthcareService.GetPatientById(patientId));
            var insuranceTask = Task.Run(() => healthcareService.GetInsuranceByPatientId(patientId));

            // Await both tasks to complete
            await Task.WhenAll(patientTask, insuranceTask);

            // Get the results
            var patient = patientTask.Result;
            var insurance = insuranceTask.Result;

            bool isValidPatient = GenericValidator.Validate(patient);
            bool isValidInsurance = GenericValidator.Validate(insurance);

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
