namespace csharp_basic;

public class Library
{
    private readonly List<Book> _books = new();

    public void AddBook(Book book)
    {
        _books.Add(book);
        Console.WriteLine($"Книга \"{book.Title}\" добавлена в библиотеку.");
    }

    // Удаление по объекту
    public bool RemoveBook(Book book) => _books.Remove(book);

    // Удаление по ISBN
    public bool RemoveBook(string isbn)
    {
        var found = _books.Find(b => string.Equals(b.Isbn, isbn, StringComparison.OrdinalIgnoreCase));
        if (found is null) return false;
        _books.Remove(found);
        return true;
    }

    // Показать все книги
    public void ShowBooks()
    {
        ShowBooks(_books);
    }

    // Универсальный вывод списка книг
    public void ShowBooks(IEnumerable<Book> books)
    {
        var list = books.ToList();
        if (list.Count == 0)
        {
            Console.WriteLine("Ничего не найдено.");
            return;
        }

        Console.WriteLine("Книги:");
        foreach (var b in list)
            Console.WriteLine(b.ToString());
    }

    /// Поиск с частичным совпадением по Title/Author/ISBN и полным совпадением по Year.
    /// Пустые или null параметры игнорируются.
    public IEnumerable<Book> Search(string? titlePart = null,
                                    string? authorPart = null,
                                    string? isbnPart = null,
                                    string? yearExact = null)
    {
        titlePart  = string.IsNullOrWhiteSpace(titlePart)  ? null : titlePart.Trim();
        authorPart = string.IsNullOrWhiteSpace(authorPart) ? null : authorPart.Trim();
        isbnPart   = string.IsNullOrWhiteSpace(isbnPart)   ? null : isbnPart.Trim();
        yearExact  = string.IsNullOrWhiteSpace(yearExact)  ? null : yearExact.Trim();

        return _books.Where(b =>
            (titlePart is null  || (b.Title  ?? string.Empty).Contains(titlePart,  StringComparison.OrdinalIgnoreCase)) &&
            (authorPart is null || (b.Author ?? string.Empty).Contains(authorPart, StringComparison.OrdinalIgnoreCase)) &&
            (isbnPart is null   || (b.Isbn   ?? string.Empty).Contains(isbnPart,   StringComparison.OrdinalIgnoreCase)) &&
            (yearExact is null  || string.Equals(b.Year, yearExact, StringComparison.Ordinal))
        );
    }

    public Book? FindByIsbn(string isbn) =>
        _books.FirstOrDefault(b => string.Equals(b.Isbn, isbn, StringComparison.OrdinalIgnoreCase));
}
