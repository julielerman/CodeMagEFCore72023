
namespace UniDirectionalM2M;

public class Patron
{
    public int PatronId { get; set; }
    public string? Name { get; set; }
    public string? MobileNumber { get; set; }
    private readonly List<Book> _books = new List<Book>();
    
    public void CheckOutBook(Book bookToCheckout)
    {
        //invariant, book must not be tied to any patron (including this one)
        if (bookToCheckout.PatronId is null)
        {
            bookToCheckout.PatronId = PatronId;
        }
    }
    public void ReturnBook(Book bookToReturn)
    {
        //invariant, book must be checked out to this patron in order to return
        if (bookToReturn.PatronId == PatronId)
        {
            bookToReturn.PatronId = null;
        }
    }
   public List<string?> CheckedOutTitles => _books.Select(b => b.Title).ToList();
}


public class Book
{
    public int BookId { get; set; }
    public int? PatronId { get; set; }
    public string? Title { get; set; }
}


