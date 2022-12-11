

using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class LibraryContext:DbContext

{

  public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }
    public LibraryContext()
    {
    }

    public DbSet<Book> Books=> Set<Book>();



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Book>().HasData(new Book { BookId=1,Title = "Olive the Newf" });

        modelBuilder.Entity<Book>().HasData(new Book { BookId = 2, Title = "My Dog" });

    }

}
