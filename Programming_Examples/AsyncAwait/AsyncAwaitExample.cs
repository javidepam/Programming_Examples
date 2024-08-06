using Programming_Examples.Services;

namespace Programming_Examples.AsyncAwait
{
    public class AsyncAwaitExample(HealthcareServiceAsync healthcareService)
    {
        public async Task FetchPatientAndInsuranceDetailsAsync(int patientId)
        {
            // Create tasks for fetching patient and insurance details
            var patientTask = healthcareService.GetPatientByIdAsync(patientId);
            var insuranceTask = healthcareService.GetInsuranceByPatientIdAsync(patientId);

            // Await both tasks to complete
            var patient = await patientTask;
            var insurance = await insuranceTask;

            // Process the results
            if (patient != null && insurance != null)
            {
                Console.WriteLine($"Patient Name: {patient.Name}, Insurance Company: {insurance.InsuranceCompany}");
            }
            else
            {
                Console.WriteLine("Failed to fetch patient or insurance details.");
            }
        }
    }
}
