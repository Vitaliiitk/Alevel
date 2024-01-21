namespace CreateDBContext
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            await using (AnimalApplicationContext context = new ConsoleApplicationContextFactory().CreateDbContext(Array.Empty<string>())) 
            {
                context.Database.EnsureCreated();
            }
        }
    }
}