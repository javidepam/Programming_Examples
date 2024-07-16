using HealthcareInsurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Services.Interfaces
{
    public interface IPatientFactory
    {
        Patient Create(string firstName, string lastName, DateTime dateOfBirth);
    }
}
