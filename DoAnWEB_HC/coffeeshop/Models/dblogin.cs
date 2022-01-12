using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace coffeeshop.Models
{
    public partial class dblogin : DbContext
    {
        public dblogin()
            : base("name=dblogin")
        {
        }

        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<USER_ROLE> USER_ROLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ROLE>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER>()
                .Property(e => e.STATUS)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER_ROLE>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER_ROLE>()
                .Property(e => e.USER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER_ROLE>()
                .Property(e => e.ROLE_ID)
                .HasPrecision(18, 0);
        }
    }
}
