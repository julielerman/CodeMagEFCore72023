

using Microsoft.EntityFrameworkCore;
namespace FilteredIncludePrivate;

public class LibraryContext:DbContext

{

    public DbSet<Patron> Patrons => Set<Patron>();
    public DbSet<Book> Books=> Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EFC7CodeMag")
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        .EnableSensitiveDataLogging();
  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patron>().HasMany("_books").WithOne();

    }

}
