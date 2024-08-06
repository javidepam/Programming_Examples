using Microsoft.EntityFrameworkCore;
using Programming_Examples.Models;
using Programming_Examples.Persistance;

namespace Programming_Examples.Services
{
    public class HealthcareServiceAsync(HealthcareContext context)
    {
        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            // Simulate fetching patient from database asynchronously
            return await context.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);
        }

        public async Task<Insurance> GetInsuranceByPatientIdAsync(int patientId)
        {
            // Simulate fetching insurance from database asynchronously
            return await context.Insurances.FirstOrDefaultAsync(i => i.PatientId == patientId);
        }
    }
}
