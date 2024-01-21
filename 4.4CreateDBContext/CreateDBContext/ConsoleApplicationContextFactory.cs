using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace CreateDBContext
{
    public sealed class ConsoleApplicationContextFactory : IDesignTimeDbContextFactory<AnimalApplicationContext>
    {
        public AnimalApplicationContext CreateDbContext(string[] args) 
        {
            var connectionString = "Data Source=LAPTOP-VVEUNF9R\\SQLEXPRESS;Initial Catalog=AnimalApplication;Integrated Security=True;;TrustServerCertificate=true";
            var optionsBuilder = new DbContextOptionsBuilder<AnimalApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return new AnimalApplicationContext(options);
        }
    }
}
