using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EzQwez.Infrastructure.EntityFrameworkDataAccess
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseNpgsql("Server=localhost;User Id=postgres;Password=o9gtBXIPvH8e8jMz7BTaowD8BskHqipjp3YcfkWzSSrc9AC5V7hYo26GMiTpSd0;Database=EzQwez");
            return new ApplicationContext(builder.Options);
        }

        //private string ReadDefaultConnectionStringFromAppSettings()
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.Production.json")
        //        .Build();

        //    string connectionString = configuration.GetConnectionString("DefaultConnection");
        //    return connectionString;
        //}
    }
}
