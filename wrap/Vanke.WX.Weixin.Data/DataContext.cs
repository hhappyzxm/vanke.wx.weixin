using System.Data.Entity;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Data
{
    public partial class DataContext : DbContext, IDataContext
    {
        public DataContext(string connectionName)
            : base("name="+ connectionName)
        {
        }
        
        public virtual DbSet<DinnerPlace> DinnerPlaces { get; set; }
        public virtual DbSet<DinnerRegisterHistory> DinnerRegisterHistories { get; set; }
        public virtual DbSet<DinnerType> DinnerTypes { get; set; }
        public virtual DbSet<EmployeeDiscount> EmployeeDiscounts { get; set; }
        public virtual DbSet<ExternalPersonnelDiningRegisterHistory> ExternalPersonnelDiningRegisterHistories { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<IdleAsset> IdleAssets { get; set; }
        public virtual DbSet<ItemBorrowHistory> ItemBorrowHistories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemStorageArea> ItemStorageAreas { get; set; }
        public virtual DbSet<ItemStoragePlace> ItemStoragePlaces { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffRole> StaffRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DinnerPlace>()
                .HasMany(e => e.DinnerRegisterHistories)
                .WithRequired(e => e.DinnerPlace)
                .HasForeignKey(e => e.PlaceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DinnerType>()
                .HasMany(e => e.DinnerRegisterHistories)
                .WithRequired(e => e.DinnerType)
                .HasForeignKey(e => e.TypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ItemBorrowHistories)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.IdleAssets)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemStorageArea>()
                .HasMany(e => e.ItemStoragePlaces)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemStorageArea>()
                .HasMany(e => e.IdleAssets)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemStoragePlace>()
                .HasMany(e => e.IdleAssets)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.DinnerRegisterHistories)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.ExternalPersonnelDiningRegisterHistories)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.ItemBorrowHistories)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.StaffRoles)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.IdleAssets)
                .WithRequired(e => e.ManagerStaff)
                .WillCascadeOnDelete(false);
        }
    }
}
