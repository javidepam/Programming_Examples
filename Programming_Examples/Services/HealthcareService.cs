using Programming_Examples.Models;
using Programming_Examples.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Examples.Services
{
    public class HealthcareService(HealthcareContext context)
    {
        private readonly HealthcareContext _context = context;

        public Patient GetPatientById(int patientId)
        {
            // Simulate fetching patient from database
            return _context.Patients.FirstOrDefault(p => p.PatientId == patientId);
        }

        public Insurance GetInsuranceByPatientId(int patientId)
        {
            // Simulate fetching insurance from database
            return _context.Insurances.FirstOrDefault(i => i.PatientId == patientId);
        }
    }

}
