using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Scratch 
{
    public class ScratchContext : DbContext
    {
        // public DbSet<Group> Groups { get; set; }
        public DbSet<Person> Persons { get; set; }
        public ScratchContext(DbContextOptions<ScratchContext> options)
            : base(options)
        {}
        class ScratchContextFactory : IDesignTimeDbContextFactory<ScratchContext>
        {
            public ScratchContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

                var optionsBuilder = new DbContextOptionsBuilder<ScratchContext>();
                optionsBuilder
                    // comment the following line if you do not want to print generated SQL statements on the console.
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]);

                return new ScratchContext(optionsBuilder.Options);
            }
        }
    }
}

