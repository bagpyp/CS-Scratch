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
        public DbSet<Friendship> Friendships { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            // what the actual fuck

            builder.Entity<Friendship>()
                .HasOne<Person>(f => f.Person)
                .WithMany(p => p.FriendshipsFrom)
                .HasForeignKey(f => f.Id);
            builder.Entity<Friendship>()
                .HasOne<Person>(f => f.OtherPerson)
                .WithMany(s => s.Friendships)
                .HasForeignKey(f => f.OtherPersonId);

            // builder.Entity<Friendship>()
            //     .HasOne(xy => xy.OtherPerson)
            //     .WithMany(x => x.Friendships)
            //     .HasForeignKey(xy => xy.PersonId)
            //     .OnDelete(DeleteBehavior.NoAction);

            // builder.Entity<Friendship>()
            //     .HasOne(xy => xy.Person)
            //     .WithMany(y => y.Friendships)
            //     .HasForeignKey(xy => xy.OtherPersonId);

        }
        public ScratchContext(DbContextOptions<ScratchContext> options)
            : base(options)
        {}
    }
    public class ScratchContextFactory : IDesignTimeDbContextFactory<ScratchContext>
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

