using csharp_basic;

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
            Console.WriteLine("5. Выйти");
            Console.Write("Ваш выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBookFlow(library);
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
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }

    static void AddBookFlow(Library library)
    {
        Console.Write("Название: ");
        var title = Console.ReadLine() ?? string.Empty;

        Console.Write("Автор: ");
        var author = Console.ReadLine() ?? string.Empty;

        Console.Write("Год (точное совпадение): ");
        var year = Console.ReadLine() ?? string.Empty;

        Console.Write("ISBN: ");
        var isbn = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
            string.IsNullOrWhiteSpace(year)  || string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("Все поля обязательны.");
            return;
        }

        if (library.FindByIsbn(isbn) is not null)
        {
            Console.WriteLine("Книга с таким ISBN уже есть.");
            return;
        }

        library.AddBook(new Book(title.Trim(), author.Trim(), year.Trim(), isbn.Trim()));
    }

    static void SearchFlow(Library library)
    {
        Console.Write("Часть названия (Enter — пропустить): ");
        var titlePart = Console.ReadLine();

        Console.Write("Часть автора (Enter — пропустить): ");
        var authorPart = Console.ReadLine();

        Console.Write("Часть ISBN (Enter — пропустить): ");
        var isbnPart = Console.ReadLine();

        Console.Write("Год (точное совпадение, Enter — пропустить): ");
        var yearExact = Console.ReadLine();

        var results = library.Search(titlePart, authorPart, isbnPart, yearExact);
        library.ShowBooks(results);
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
}
