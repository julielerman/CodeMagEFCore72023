using Microsoft.EntityFrameworkCore;
using UniDirectionalM2M;

var context = new LibraryContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Seed();

var patrons = context.Patrons.ToList();
Console.WriteLine(patrons.FirstOrDefault().MobileNumber);




void Seed()
{
    var p1 = new Patron { Name = "Onslow", MobileNumber = "1111" };
    var p2 = new Patron { Name = "Hyacinth", MobileNumber = "2222" };
    var p3 = new Patron { Name = "Newfie Owner", MobileNumber = "3333" };
    context.Patrons.AddRange(p1, p2, p3);
    context.SaveChanges();
}