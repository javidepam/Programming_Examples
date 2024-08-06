using Programming_Examples.Threading;

namespace Programming_Examples.Handlers
{
    internal class ThreadingHandler(BasicThreadingExample basicThreadingExample)
    {
        private readonly BasicThreadingExample? _basicThreadingExample = basicThreadingExample;

        public void PatientInsuranceThreading()
        {
            //var example = new HealthcareThreadingExample(healthcareService);

            int patientId = 1; // Example patient ID
            _basicThreadingExample?.FetchPatientAndInsuranceDetails(patientId);
        }
    }
    
}
