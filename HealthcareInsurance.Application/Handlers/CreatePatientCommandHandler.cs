using HealthcareInsurance.Application.Commands;
using HealthcareInsurance.Application.Services;
using HealthcareInsurance.Application.Services.Interfaces;
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
        private readonly IPatientFactory _patientFactory; //Uses Factory

        public CreatePatientCommandHandler(IApplicationDbContext context, IPatientFactory patientFactory)
        {
            _context = context;
            _patientFactory = patientFactory;
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

            //Uses Factory Pattern
            var patient = _patientFactory.Create(request.FirstName, request.LastName, request.DateOfBirth);
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync(cancellationToken);

            LoggerService.Instance.Log($"Patient {patient.FirstName} created.");

            return entity.PatientId;
        }
    }
}
