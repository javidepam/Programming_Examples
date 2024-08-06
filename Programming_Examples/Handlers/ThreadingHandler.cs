using Programming_Examples.Threading;

namespace Programming_Examples.Handlers
{
    internal class ThreadingHandler
    {
        private readonly BasicThreadingExample? _basicThreadingExample = null;

        public ThreadingHandler(BasicThreadingExample basicThreadingExample) 
        {
            _basicThreadingExample = basicThreadingExample;
        }

        public void PatientInsuranceThreading()
        {
            //var example = new HealthcareThreadingExample(healthcareService);

            int patientId = 1; // Example patient ID
            _basicThreadingExample?.FetchPatientAndInsuranceDetails(patientId);
        }
    }
    
}
