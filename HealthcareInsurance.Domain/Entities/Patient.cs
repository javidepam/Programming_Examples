using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Domain.Entities
{
    public record Patient(int PatientId, string? FirstName, string? LastName, DateTime DateOfBirth, string? Address, string? PhoneNumber, string? Email)
    {
        // Constructor
        public Patient() : this(default, default, default, default, default, default, default)
        {
            // Initialize any default values if needed
        }
    }
}
