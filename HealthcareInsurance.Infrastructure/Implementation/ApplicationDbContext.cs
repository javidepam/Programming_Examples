using HealthcareInsurance.Domain.Entities;
using HealthcareInsurance.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthcareInsurance.Infrastructure.Implementation
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private bool _disposed = false;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Patient> Patients { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
