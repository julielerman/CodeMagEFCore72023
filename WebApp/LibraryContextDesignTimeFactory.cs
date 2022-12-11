using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
         public class LibraryContextDesignTimeFactory : IDesignTimeDbContextFactory<LibraryContext>
        {
            public LibraryContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EFC7CodeMagWebLocal");


                return new LibraryContext(optionsBuilder.Options);
            }
        }
    
}
