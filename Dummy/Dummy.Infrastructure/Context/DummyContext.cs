using Dummy.Domain.Models;
using Dummy.Infrastructure.ConfigModels;
using Microsoft.EntityFrameworkCore;

namespace Dummy.Infrastructure.Context
{
    public class DummyContext : DbContext
    {
        public DummyContext(DbContextOptions options) : base(options) { }
        public DummyContext() { }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<TypeContact> TypeContact { get; set; }

        public DbSet<LogContact> LogContact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HRQO58R0;Initial Catalog=Dummydb;Integrated Security=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleConfig());
            modelBuilder.ApplyConfiguration(new TypeContactConfig());
            base.OnModelCreating(modelBuilder);
        }
       

    }
}
