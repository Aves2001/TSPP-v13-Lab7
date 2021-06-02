using System;

namespace Lab7
{
    class Program
    {
        static void Main()
        {
            Vegetable[] veg = new Vegetable[10];
            veg[0] = new Vegetable("1", "Баклажан", "150", "18", "100");
            veg[1] = new Vegetable("2", "Буряк", "70", "37", "58");
            veg[2] = new Vegetable("3", "Гарбуз", "82", "28", "90");
            veg[3] = new Vegetable("4", "Кабачки", "122", "23", "130");
            veg[4] = new Vegetable("5", "Картопля", "80", "80", "120");
            veg[5] = new Vegetable("6", "Кріп", "92", "28", "20");
            veg[6] = new Vegetable("7", "Кукурудза", "80", "97", "65");
            veg[7] = new Vegetable("8", "Огірок", "70", "15", "86");
            veg[8] = new Vegetable("9", "Патісони", "94", "19", "76");
            veg[9] = new Vegetable("10", "Помідори", "105", "19", "86");

            try
            {
                char task; // для збереження натиснутої клавіші
                do
                {
                    Console.WriteLine("\nГарячі клавіші:\n");
                    Console.WriteLine("[0] ------ Cписок овочів, впорядкований за ID.\n");
                    Console.WriteLine("[1] --- А) IComparable список овочів, впорядкований за ціною.");
                    Console.WriteLine("[2] --- Б) IComparer список овочів впорядкований за ціною і за кількістю ящиків на складі.");
                    Console.WriteLine("[3] --- В) IEnumerable, список овочів, впорядкований за ціною.");
                    Console.WriteLine("\n[ESC] --- Вихід\n");

                    Console.Write(">");
                    task = Console.ReadKey(true).KeyChar; // присвоєння натиснутої клавіші
                    Console.Clear(); // очистка консолі
                    switch (task)
                    {
                        case (char)ConsoleKey.Escape: // якщо нажали ESC виходить з програми
                            break;

                        case '0':
                            Console.WriteLine("\nCписок овочів, впорядкований ID:");
                            Array.Sort(veg, new Vegetable.SortByID());
                            Vegetable.ShowTable(veg);
                            _ = Console.ReadKey(true);
                            Console.Clear();
                            break;

                        case '1':
                            Console.WriteLine("\nIComparable. Cписок овочів, впорядкований за ціною:");
                            Array.Sort(veg);
                            Vegetable.ShowTable(veg);
                            _ = Console.ReadKey(true);
                            Console.Clear();
                            break;

                        case '2':
                            Console.WriteLine("\nIComparer. Cписок овочів, впорядкований за ціною і за кількістю ящиків на складі:");
                            Array.Sort(veg, new Vegetable.SortByPriceNumber());
                            Vegetable.ShowTable(veg);
                            _ = Console.ReadKey(true);
                            Console.Clear();
                            break;

                        case '3':
                            Console.WriteLine("\nIEnumerable. Cписок овочів, впорядкований за ціною:");
                            Array.Sort(veg, new Vegetable.SortByPrice());
                            Vegetables vegetables = new Vegetables(veg);
                            Vegetable.ShowTable(vegetables.Container);
                            _ = Console.ReadKey(true);
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\nПомилка: Такого пункта немає\n\n");
                            break;
                    }
                } while (task != (char)ConsoleKey.Escape); // якщо нажали ESC виходить з програми
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
        }
    }
}
