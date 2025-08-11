class Program
{
    static void Main()
    {
        var books = new string[5, 4];

        // Первая книга
        Console.WriteLine("Добавление первой книги:");
        Console.Write("Введите автора: ");
        books[0, 0] = Console.ReadLine();
        Console.Write("Введите название: ");
        books[0, 1] = Console.ReadLine();
        Console.Write("Введите год: ");
        books[0, 2] = Console.ReadLine();
        Console.Write("Введите ISBN: ");
        books[0, 3] = Console.ReadLine();

        // Вторая книга
        Console.WriteLine("\nДобавление второй книги:");
        Console.Write("Введите автора: ");
        books[1, 0] = Console.ReadLine();
        Console.Write("Введите название: ");
        books[1, 1] = Console.ReadLine();
        Console.Write("Введите год: ");
        books[1, 2] = Console.ReadLine();
        Console.Write("Введите ISBN: ");
        books[1, 3] = Console.ReadLine();

        // Третья книга
        Console.WriteLine("\nДобавление третьей книги:");
        Console.Write("Введите автора: ");
        books[2, 0] = Console.ReadLine();
        Console.Write("Введите название: ");
        books[2, 1] = Console.ReadLine();
        Console.Write("Введите год: ");
        books[2, 2] = Console.ReadLine();
        Console.Write("Введите ISBN: ");
        books[2, 3] = Console.ReadLine();

        // Четвёртая книга
        Console.WriteLine("\nДобавление четвёртой книги:");
        Console.Write("Введите автора: ");
        books[3, 0] = Console.ReadLine();
        Console.Write("Введите название: ");
        books[3, 1] = Console.ReadLine();
        Console.Write("Введите год: ");
        books[3, 2] = Console.ReadLine();
        Console.Write("Введите ISBN: ");
        books[3, 3] = Console.ReadLine();

        // Пятая книга
        Console.WriteLine("\nДобавление пятой книги:");
        Console.Write("Введите автора: ");
        books[4, 0] = Console.ReadLine();
        Console.Write("Введите название: ");
        books[4, 1] = Console.ReadLine();
        Console.Write("Введите год: ");
        books[4, 2] = Console.ReadLine();
        Console.Write("Введите ISBN: ");
        books[4, 3] = Console.ReadLine();

        // Вывод всех книг
        Console.WriteLine("\nСписок книг:");
        Console.WriteLine($"1. Автор: {books[0, 0]}, Название: {books[0, 1]}, Год: {books[0, 2]}, ISBN: {books[0, 3]}");
        Console.WriteLine($"2. Автор: {books[1, 0]}, Название: {books[1, 1]}, Год: {books[1, 2]}, ISBN: {books[1, 3]}");
        Console.WriteLine($"3. Автор: {books[2, 0]}, Название: {books[2, 1]}, Год: {books[2, 2]}, ISBN: {books[2, 3]}");
        Console.WriteLine($"4. Автор: {books[3, 0]}, Название: {books[3, 1]}, Год: {books[3, 2]}, ISBN: {books[3, 3]}");
        Console.WriteLine($"5. Автор: {books[4, 0]}, Название: {books[4, 1]}, Год: {books[4, 2]}, ISBN: {books[4, 3]}");
    }
}
