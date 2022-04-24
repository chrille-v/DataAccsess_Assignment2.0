using DataAccsess_Assignment2._0.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccsess_Assignment2._0.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AddressEntity>()
            //    .HasKey(x => x.CustomerId);
        }

        public virtual DbSet<CustomerEntity> Customer { get; set; }
        public virtual DbSet<AddressEntity> Address { get; set; }
        public virtual DbSet<ProductEntity> Product { get; set; }
        public virtual DbSet<CategoryEntity> Category { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
    }
}
