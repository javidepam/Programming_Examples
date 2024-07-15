using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Domain.Entities
{
    internal record InsurancePolicy(int PolicyId, string? PolicyNumber, string? PolicyHolder, DateTime StartDate, DateTime EndDate, decimal PremiumAmount, bool IsActive)
    {
        // Constructor
        public InsurancePolicy() : this(default, default, default, default, default, default, true)
        {
            // Initialize any default values if needed
            // Assuming all policies are active by default
        }
    }
}
