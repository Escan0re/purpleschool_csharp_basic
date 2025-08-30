using System;
using System.Linq;

namespace csharp_basic;

class Program
{
    static void Main()
    {
        var library = new Library();

        while (true)
        {
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Показать все книги");
            Console.WriteLine("3. Поиск книг");
            Console.WriteLine("4. Удалить книгу по ISBN");
            Console.WriteLine("5. Сохранить библиотеку в файл");
            Console.WriteLine("6. Загрузить библиотеку из файла");
            Console.WriteLine("7. Выйти");
            Console.Write("Ваш выбор: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddBook(library);
                    break;
                case "2":
                    library.ShowBooks();
                    break;
                case "3":
                    SearchFlow(library);
                    break;
                case "4":
                    RemoveFlow(library);
                    break;
                case "5":
                    library.SaveToFile("library.json");
                    break;
                case "6":
                    library.LoadFromFile("library.json");
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void AddBook(Library library)
    {
        Console.Write("Название: ");
        var title = Console.ReadLine();

        Console.Write("Автор: ");
        var author = Console.ReadLine();

        var year = ReadValidYear();
        var isbn = ReadValidIsbn();

        Console.Write("Комментарий: ");
        var comment = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Поля Название и Автор обязательны.");
            return;
        }

        library.AddBook(new Book(title!, author!, year!, isbn!, comment));
    }

    static void SearchFlow(Library library)
    {
        Console.WriteLine("Поиск по: 1) Названию  2) Автору  3) Году  4) ISBN");
        var ch = Console.ReadLine();
        switch (ch)
        {
            case "1":
                Console.Write("Введите часть названия: ");
                foreach (var b in library.FindByTitle(Console.ReadLine() ?? ""))
                    Console.WriteLine(b);
                break;
            case "2":
                Console.Write("Введите часть имени автора: ");
                foreach (var b in library.FindByAuthor(Console.ReadLine() ?? ""))
                    Console.WriteLine(b);
                break;
            case "3":
                Console.Write("Введите год: ");
                foreach (var b in library.FindByYear(Console.ReadLine() ?? ""))
                    Console.WriteLine(b);
                break;
            case "4":
                Console.Write("Введите ISBN: ");
                var found = library.FindByIsbn(Console.ReadLine() ?? "");
                Console.WriteLine(found is null ? "Не найдено" : found);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static void RemoveFlow(Library library)
    {
        Console.Write("Введите ISBN книги для удаления: ");
        var isbn = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("ISBN не может быть пустым.");
            return;
        }
        if (library.RemoveBook(isbn.Trim()))
            Console.WriteLine("Книга удалена.");
        else
            Console.WriteLine("Книга не найдена.");
    }

    static string ReadValidYear()
    {
        var max = DateTime.Now.Year;
        while (true)
        {
            Console.Write($"Год издания (1450–{max}): ");
            var s = Console.ReadLine();
            if (int.TryParse(s, out var y) && y >= 1450 && y <= max)
                return y.ToString();
            Console.WriteLine("Некорректный год.");
        }
    }

    static string ReadValidIsbn()
    {
        while (true)
        {
            Console.Write("ISBN (10/13): ");
            var raw = Console.ReadLine();
            var s = new string((raw ?? "").Where(c => char.IsDigit(c) || c == 'X' || c == 'x').ToArray());
            if (IsValidIsbn10(s) || IsValidIsbn13(s))
                return s.ToUpperInvariant();
            Console.WriteLine("Некорректный ISBN.");
        }
    }

    static bool IsValidIsbn10(string s)
    {
        if (s.Length != 10) return false;
        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            int v;
            if (i == 9 && (s[i] == 'X' || s[i] == 'x')) v = 10;
            else if (char.IsDigit(s[i])) v = s[i] - '0';
            else return false;
            sum += v * (10 - i);
        }
        return sum % 11 == 0;
    }

    static bool IsValidIsbn13(string s)
    {
        if (s.Length != 13 || !s.All(char.IsDigit)) return false;
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            var d = s[i] - '0';
            sum += (i % 2 == 0) ? d : d * 3;
        }
        var check = (10 - (sum % 10)) % 10;
        return check == (s[12] - '0');
    }
}
