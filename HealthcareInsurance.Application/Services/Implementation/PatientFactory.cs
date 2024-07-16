using HealthcareInsurance.Application.Services.Interfaces;
using HealthcareInsurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Services.Implementation
{
    public class PatientFactory : IPatientFactory
    {
        public Patient Create(string firstName,string lastName, DateTime dateOfBirth)
        {
            return new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };
        }
    }
}
