using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Commands
{
    public record CreatePatientCommand(string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email) : IRequest<int>;
}
