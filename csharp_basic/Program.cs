class Program
{
    static void Main()
    {
        var books = new string[5, 4];
        var index = 0;

        while (true)
        {
            Console.WriteLine("1. Добавить книгу\n2. Показать книги\n3. Выйти");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                if (index >= books.Length)
                {
                    Console.WriteLine("Нет места для новых книг!");
                    continue;
                }

                Console.Write("Автор: ");
                books[index, 0] = Console.ReadLine();
                Console.Write("Название: ");
                books[index, 1] = Console.ReadLine();
                Console.Write("Год: ");
                books[index, 2] = Console.ReadLine();
                Console.Write("ISBN: ");
                books[index, 3] = Console.ReadLine();

                index++;
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nСписок книг:");
                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine($"{i + 1}. Автор: {books[i, 0]}, Название: {books[i, 1]}, Год: {books[i, 2]}, ISBN: {books[i, 3]}");
                }
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}