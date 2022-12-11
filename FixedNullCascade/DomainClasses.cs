
namespace FixedNullCascade;

public class Patron
{
    public int PatronId { get; set; }
    public string? Name { get; set; }
   public List<Book> Books { get; set; } = new List<Book>();
    }


public class Book
{
    public int BookId { get; set; }
    public int? PatronId { get; set; }
    public string? Title { get; set; }
}


