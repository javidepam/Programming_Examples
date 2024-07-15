using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Domain.Entities
{
    internal record MedicalRecord(int MedicalRecordId, Patient Patient, DateTime VisitDate, string? Diagnosis, string? Treatment);
}
