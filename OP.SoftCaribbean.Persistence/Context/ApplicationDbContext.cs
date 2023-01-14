using Microsoft.EntityFrameworkCore;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Domain.Common;
using OP.SoftCaribbean.Domain.Entities;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }
        public DbSet<Maestras> Maestras { get; set; }
        public DbSet<DataMaestra> DataMaestra { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.feregistro = _dateTime.NowUtc;
                        break;
                    case EntityState.Added:
                        entry.Entity.febaja = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
