using System.Data.Entity;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Data
{
    public partial class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("name=SQLConnection")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DinnerPlace> DinnerPlaces { get; set; }
        public virtual DbSet<DinnerRegisterHistory> DinnerRegisterHistories { get; set; }
        public virtual DbSet<DinnerType> DinnerTypes { get; set; }
        public virtual DbSet<ExternalPersonnelDiningRegisterHistory> ExternalPersonnelDiningRegisterHistories { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.LoginName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<DinnerPlace>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<DinnerPlace>()
                .HasMany(e => e.DinnerRegisterHistories)
                .WithRequired(e => e.DinnerPlace)
                .HasForeignKey(e => e.PlaceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DinnerRegisterHistory>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<DinnerType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<DinnerType>()
                .HasMany(e => e.DinnerRegisterHistories)
                .WithRequired(e => e.DinnerType)
                .HasForeignKey(e => e.TypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExternalPersonnelDiningRegisterHistory>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.RealName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.LoginName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.DinnerRegisterHistories)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasOptional(e => e.ExternalPersonnelDiningRegisterHistory)
                .WithRequired(e => e.Staff);
        }
    }
}
