namespace RentalShopApp.Data
{
    using RentalShopApp.Entities;
    using Microsoft.EntityFrameworkCore;
    public class RentalShopAppDbContext: DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<PCGame> PCGames => Set<PCGame>();
        public DbSet<CDMusic> CDsMusic => Set<CDMusic>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Employee> Employees => Set<Employee>();
        public RentalShopAppDbContext()
        { 
            Database.EnsureCreated();
            SaveChanges();
        }
        public RentalShopAppDbContext(DbContextOptions<RentalShopAppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
            SaveChanges();
        }

         
    }
}
