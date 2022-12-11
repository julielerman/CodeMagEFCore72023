// See https://aka.ms/new-console-template for more information
//seed
using Microsoft.EntityFrameworkCore;
using UniDirectionalM2M;

var context = new LibraryContext();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    Seed();
var oliveBook = context.Books.Include(b => b.Categories).FirstOrDefault(x => x.Title == "Olive");
oliveBook.Categories.ForEach(c => Console.WriteLine(c.Name));

void Seed()
{
    var c1 = new Category { Name = "Dogs" };
    var c2 = new Category { Name = "Newfoundlands" };
    var b1 = new Book { Title = "My Dog" };
    b1.Categories.Add(c1);
    var b2 = new Book { Title = "Olive" };
    b2.Categories.AddRange(new Category[] { c1, c2 });
    context.Books.AddRange(b1, b2);
    context.SaveChanges();


}