using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository.Identity
{
    public class IdentityContext: IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options)
        {
            
        }

        // In this method we override OnModelCreating which exist in base class
        // so we need to call it
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
        }
    }
}