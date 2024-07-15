using HealthcareInsurance.Application.Commands;
using HealthcareInsurance.Domain.Entities;
using HealthcareInsurance.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Handlers
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePatientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };

            _context.Patients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.PatientId;
        }
    }
}
