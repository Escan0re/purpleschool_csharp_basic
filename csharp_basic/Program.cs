Console.WriteLine($"Выберите действие:\n1. Добавить книгу\n2. Показать книгу\n3. Выйти");
var userChoose = Console.ReadLine();

if (userChoose == "1")
    Console.WriteLine("Книга добавлена");

if (userChoose == "2")
    Console.WriteLine("Книга");

if (userChoose == "3")
    Console.WriteLine("Вы вышли");

if (userChoose != "1" && userChoose != "2" && userChoose != "3")
    Console.WriteLine("Неизвестная команда");