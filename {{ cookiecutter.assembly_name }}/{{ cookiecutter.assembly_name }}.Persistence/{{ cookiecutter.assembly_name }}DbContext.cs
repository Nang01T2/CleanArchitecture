using {{ cookiecutter.assembly_name }}.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{ cookiecutter.assembly_name }}.Persistence
{
    public class {{ cookiecutter.assembly_name }}DbContext: AuditableDbContext
    {
        public {{ cookiecutter.assembly_name }}DbContext(DbContextOptions<{{ cookiecutter.assembly_name }}DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof({{ cookiecutter.assembly_name }}DbContext).Assembly);
        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    }
}
