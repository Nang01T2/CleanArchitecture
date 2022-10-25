using {{ cookiecutter.assembly_name }}.Identity.Configurations;
using {{ cookiecutter.assembly_name }}.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{ cookiecutter.assembly_name }}.Identity
{
    public class {{ cookiecutter.assembly_name }}IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public {{ cookiecutter.assembly_name }}IdentityDbContext(DbContextOptions<{{ cookiecutter.assembly_name }}IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
