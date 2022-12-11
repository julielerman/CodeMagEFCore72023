
using FilteredIncludePrivate;
using Microsoft.EntityFrameworkCore;


var context = new LibraryContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Seed();
context.ChangeTracker.Clear();

var patron = context.Patrons.Include("_books").ToList();
patron = context.Patrons.Include(p => EF.Property<Book>(p, "_books")).ToList();
patron = context.Patrons.Include(p => EF.Property<ICollection<Book>>(p, "_books")
  .OrderBy(b => b.Title)).ToList();



void Seed()
{
    var p1 = new Patron { Name = "Onslow" };
    var p2 = new Patron { Name = "Hyacinth" };
    var p3 = new Patron { Name = "Newfie Owner" };
    context.Patrons.AddRange(p1, p2, p3);
    var b1=new Book { Title = "My Dog Named Dog" };
    var b2=new Book { Title = "I Love My Tea Set" };
    var b3=new Book { Title = "Olive the Dog" };
    context.Books.AddRange(b1, b2, b3);
    context.SaveChanges();
    p1.CheckOutBook(b1);
    p2.CheckOutBook(b2 );
    p3.CheckOutBook(b3);
    context.SaveChanges();

}