using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentCarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database=RentCar;Trusted_Connection=true");
        }
        public DbSet<Car> CARS { get; set; }
        public DbSet<Brand> BRANDS { get; set; }
        public DbSet<Color> COLORS { get; set; }
        public DbSet<User> USERS { get; set; }
        public DbSet<Customer> CUSTOMERS { get; set; }
        public DbSet<Rental> RENTALS { get; set; }
        public DbSet<CarImage> CARIMAGES { get; set; }
        public DbSet<OperationClaim> OPERATIONCLAIMS { get; set; }
        public DbSet<UserOperationClaim> USEROPERATIONCLAIMS { get; set; }
    }
}
