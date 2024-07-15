using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Domain.Entities
{
    internal record InsuranceCompany(int InsuranceCompanyId, string? Name, string? Address, string? PhoneNumber);
}
