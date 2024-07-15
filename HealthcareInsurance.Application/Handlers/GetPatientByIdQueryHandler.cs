using HealthcareInsurance.Application.Queries;
using HealthcareInsurance.Domain.Entities;
using HealthcareInsurance.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Handlers
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient>
    {
        private readonly IApplicationDbContext _context;

        public GetPatientByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.PatientId == request.Id, cancellationToken);
        }
    }
}
