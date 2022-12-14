using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Мебель
{
    public partial class FurnitureContext : DbContext
    {
        public FurnitureContext()
            : base("name=FurnitureContext")
        {
        }

        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FurnitureColor> FurnitureColors { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<FurnitureType> FurnitureTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ShopList> ShopLists { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Furnitures)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.UnitsId);
        }
    }
}
