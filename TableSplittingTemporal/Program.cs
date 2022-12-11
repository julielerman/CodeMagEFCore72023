
using TableSplittingTemporal;


var context = new LibraryContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Seed();

var patron = context.Patrons.FirstOrDefault();
Console.WriteLine(patron.ContactInfo.MobileNumber);




void Seed()
{
    var p1 = new Patron
    {
        Name = "Onslow",
        ContactInfo = new ContactInfo { MobileNumber = "1111" }
    };
    context.Patrons.AddRange(p1);
    context.SaveChanges();
}