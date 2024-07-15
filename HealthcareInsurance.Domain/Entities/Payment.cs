using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Domain.Entities
{
    internal record Payment(int PaymentId, Claim Claim, DateTime PaymentDate, decimal Amount, string PaymentMethod);
}
