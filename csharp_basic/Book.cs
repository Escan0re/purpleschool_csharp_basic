namespace csharp_basic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Year { get; set; }
    public string Isbn { get; set; }

    public Book(string title, string author, string year, string isbn)
    {
        Title = title;
        Author = author;
        Year = year;
        Isbn = isbn;
    }

    public override string ToString() => $"{Title} — {Author}, {Year}, ISBN: {Isbn}";
}
