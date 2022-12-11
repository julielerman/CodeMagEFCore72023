
using System.ComponentModel;

namespace WebApp;


public class Book
{
    public int BookId { get; set; }
    public int? PatronId { get; set; }
    public string? Title { get; set; }
}
