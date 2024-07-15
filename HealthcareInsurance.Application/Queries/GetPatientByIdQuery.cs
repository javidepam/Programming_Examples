using HealthcareInsurance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Queries
{
    public record GetPatientByIdQuery(int Id) : IRequest<Patient>;
}
