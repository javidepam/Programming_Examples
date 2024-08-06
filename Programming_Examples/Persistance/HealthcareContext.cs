using Microsoft.EntityFrameworkCore;
using Programming_Examples.Models;

namespace Programming_Examples.Persistance
{
    public class HealthcareContext(DbContextOptions<HealthcareContext> options) : DbContext(options)
    {
        private bool _disposed = false;

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
