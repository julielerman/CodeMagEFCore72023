// See https://aka.ms/new-console-template for more information
//seed
using FixedNullCascade;


var context = new LibraryContext();

//cascade default
//EF Core 6 code syntax to run with EF Core 6 testing
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    Seed();
    context.ChangeTracker.Clear();
    var bookCountBefore = context.Books.Count();

    var book = context.Books.FirstOrDefault();
    book.PatronId = null;
    context.SaveChanges();
    var bookCountAfter = context.Books.Count();
    Console.WriteLine($"Before {bookCountBefore}, After {bookCountAfter}");


void Seed()
{
    var p1 = new Patron { Name = "Onslow" };
    p1.Books.Add(new Book { Title = "My Dog Named My Dog" });
    var p2 = new Patron { Name = "Hyacinth" };
    p1.Books.Add(new Book { Title = "I Love My Tea Set" });
    var p3 = new Patron { Name = "Newfie Owner" };
    p3.Books.Add(new Book { Title = "Olive the Dog" });
    context.Patrons.AddRange(p1, p2, p3);
    context.SaveChanges();
}