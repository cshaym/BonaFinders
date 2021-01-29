using BonaFinders.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Adding database entry properties
        public DbSet<EthicalOrganization> EthicalOrganizations { get; set; }
        public DbSet<UnethicalOrganization> UnethicalOrganizations { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<EthicalReview> EthicalReviews { get; set; }
        public DbSet<UnethicalReview> UnethicalReviews { get; set; }


        // Adding override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }

}
