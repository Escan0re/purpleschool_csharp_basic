using System;

class Program
{
    static void Main()
    {
        var books = new string[5, 4];
        int index = 0;

        while (true)
        {
            Console.WriteLine("1. Добавить книгу\n2. Показать книги\n3. Поиск книги\n4. Выйти");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                if (index >= books.GetLength(0))
                {
                    Console.WriteLine("Нет места для новых книг!");
                    continue;
                }

                Console.Write("Автор: ");   books[index, 0] = Console.ReadLine();
                Console.Write("Название: "); books[index, 1] = Console.ReadLine();
                Console.Write("Год: ");      books[index, 2] = Console.ReadLine();
                Console.Write("ISBN: ");     books[index, 3] = Console.ReadLine();
                index++;
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nСписок книг:");
                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine($"{i + 1}. Автор: {books[i,0]}, Название: {books[i,1]}, Год: {books[i,2]}, ISBN: {books[i,3]}");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("1. Поиск по автору\n2. Поиск по названию\n3. Поиск по году\n4. Поиск по ISBN");
                if (!int.TryParse(Console.ReadLine(), out int searchChoice) || searchChoice < 1 || searchChoice > 4)
                {
                    Console.WriteLine("Неверный выбор.");
                    continue;
                }

                int column = searchChoice - 1;

                Console.Write("Введите запрос: ");
                string query = Console.ReadLine() ?? "";

                bool found = false;
                for (int i = 0; i < index; i++)
                {
                    var field = books[i, column];
                    if (!string.IsNullOrEmpty(field) &&
                        field.Contains(query, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{i + 1}. Автор: {books[i,0]}, Название: {books[i,1]}, Год: {books[i,2]}, ISBN: {books[i,3]}");
                        found = true;
                    }
                }
                if (!found) Console.WriteLine("Ничего не найдено.");
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}
