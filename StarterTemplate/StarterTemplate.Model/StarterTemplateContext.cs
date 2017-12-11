using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StarterTemplate.Model
{
    public class StarterTemplateContext : DbContext
    {
        public StarterTemplateContext() : base("Name=StarterTemplateContext")
        {

        }

        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            ModifyDatetime();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            ModifyDatetime();
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ModifyDatetime();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ModifyDatetime()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                   // string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        //entity.CreatedBy = identityName;
                        entity.CreatedDateTime = now;
                    }
                    else
                    {
                        //base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDateTime).IsModified = false;
                    }

                    //entity.UpdatedBy = identityName;
                    entity.UpdatedDateTime = now;
                }
            }
        }
    }
}
