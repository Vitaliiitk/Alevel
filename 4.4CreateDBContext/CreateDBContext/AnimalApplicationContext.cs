using CreateDBContext.Models;
using Microsoft.EntityFrameworkCore;


namespace CreateDBContext
{
    public sealed class AnimalApplicationContext: DbContext
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public AnimalApplicationContext(DbContextOptions<AnimalApplicationContext> options) : base(options) 
        {

        }
       
    }

   
}

