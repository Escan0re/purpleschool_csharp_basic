using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace csharp_basic;

public class Library
{
    private readonly List<Book> _books = new();

    public void AddBook(Book book)
    {
        // Проверка ISBN
        if (_books.Any(b => b.Isbn == book.Isbn))
        {
            Console.WriteLine("Книга с таким ISBN уже существует.");
            return;
        }

        // Проверка дубликата (Автор + Название + Год)
        if (_books.Any(b => b.Title == book.Title && b.Author == book.Author && b.Year == book.Year))
        {
            Console.WriteLine("Такая книга уже есть (Автор+Название+Год).");
            return;
        }

        _books.Add(book);
        Console.WriteLine($"Книга \"{book.Title}\" добавлена в библиотеку.");
    }

    public void ShowBooks()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
            return;
        }

        foreach (var b in _books)
            Console.WriteLine(b);
    }

    public bool RemoveBook(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.Isbn == isbn);
        if (book != null)
        {
            _books.Remove(book);
            return true;
        }
        return false;
    }

    public Book FindByIsbn(string isbn)
    {
        return _books.FirstOrDefault(b => b.Isbn == isbn);
    }

    public List<Book> FindByTitle(string title)
    {
        var result = new List<Book>();
        foreach (var b in _books)
            if (b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                result.Add(b);
        return result;
    }

    public List<Book> FindByAuthor(string author)
    {
        var result = new List<Book>();
        foreach (var b in _books)
            if (b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                result.Add(b);
        return result;
    }

    public List<Book> FindByYear(string year)
    {
        var result = new List<Book>();
        foreach (var b in _books)
            if (b.Year == year)
                result.Add(b);
        return result;
    }

    // Сохранение и загрузка
    public void SaveToFile(string path)
    {
        var json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(path, json);
        Console.WriteLine("Сохранено.");
    }

    public void LoadFromFile(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        var json = System.IO.File.ReadAllText(path);
        var data = JsonSerializer.Deserialize<List<Book>>(json);
        _books.Clear();
        if (data != null) _books.AddRange(data);
        Console.WriteLine("Загружено.");
    }
}
