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
    }
}
