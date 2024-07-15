using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Domain.Entities
{
    internal record Claim(int ClaimId, InsurancePolicy Policy, DateTime ClaimDate, decimal ClaimAmount, string Status);
}
