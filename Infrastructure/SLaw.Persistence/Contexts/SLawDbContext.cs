using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SLaw.Domain.Entities;
using SLaw.Domain.Entities.Common;
using SLaw.Domain.Entities.Identity;

namespace SLaw.Persistence.Contexts
{
    public class SLawDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Lawyer> Lawyers { get; set; }

        public DbSet<PracticeArea> PracticeAreas { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }

        public DbSet<ContactForm> ContactForms { get; set; }

        public SLawDbContext(DbContextOptions options) : base(options) { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            //Yeni bir entity eklediğimizde veya güncellediğimizde tarihleri merkezi bir yerden güncelliyoruz.

            IEnumerable<EntityEntry<BaseEntity>> datas = this.ChangeTracker.Entries<BaseEntity>();

            foreach (EntityEntry<BaseEntity> data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added    => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _                    => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
