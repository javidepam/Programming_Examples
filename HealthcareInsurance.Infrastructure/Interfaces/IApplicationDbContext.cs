using HealthcareInsurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Patient> Patients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
