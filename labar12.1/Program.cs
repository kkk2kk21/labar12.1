using library;

namespace labar12._1
{
    internal class Program
    {
        static void Main()
        {
            MyList<zAircraft>? list = new MyList<zAircraft>();
            MyList<zAircraft>? clonedList = new MyList<zAircraft>();
            bool exit = false;

            do
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Сформировать двунаправленный список и заполнить его случайными значениями");
                Console.WriteLine("2. Распечатать двунаправленный список");
                Console.WriteLine("3. Добавить в список элемент с заданным номером");
                Console.WriteLine("4. Удалить из списка все нечетные элементы");
                Console.WriteLine("5. Выполнить глубокое копирование (клонирование)");
                Console.WriteLine("6. Распечатать склонированный список");
                Console.WriteLine("7. Удалить список из памяти");
                Console.WriteLine("8. Удалить склонированный список из памяти");
                Console.WriteLine("9. Завершить работу");

                int number = IntManualInput(1, 9);
                switch (number)
                {
                    case 1:
                        list = CreateList();
                        break;
                    case 2:
                        list.PrintList();
                        break;
                    case 3:
                        AddPointIndex(list);
                        break;
                    case 4:
                        list.RemoveOddIndexes();
                        break;
                    case 5:
                        clonedList = CloneList(list);
                        break;
                    case 6:
                        clonedList.PrintList();
                        break;
                    case 7:
                        list.DeleteList();
                        break;
                    case 8:
                        clonedList.DeleteList();
                        break;
                    case 9:
                        exit = true;
                        break;
                }
            } while (!exit);
        }

        static int IntManualInput(int min, int max)
        {
            bool ok;
            int number;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (!ok)
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                }
                else if (number < min || number > max)
                {
                    Console.WriteLine($"Число находится вне диапазона {min} и {max}, попробуйте еще раз");
                    ok = false;
                }
            } while (!ok);

            return number;
        }

        static MyList<zAircraft> CreateList()
        {
            Console.WriteLine("Введите длину списка (от 1 до 100)");
            int size = IntManualInput(1, 100);
            MyList<zAircraft> newList = new MyList<zAircraft>(size);
            return newList;
        }

        static void AddPointIndex(MyList<zAircraft> list)
        {
            Console.WriteLine($"Введите индекс, по которому нужно добавить элемент (от 1 до {list.count + 1}):");
            int index = IntManualInput(1, list.count + 1);

            zAircraft newItem = new zAircraft();
            newItem.RandomInit();

            list.AddPointByIndex(index - 1, newItem);
            Console.WriteLine("Элемент добавлен в список");
        }

        static MyList<zAircraft> CloneList(MyList<zAircraft> list)
        {
            try
            {
                MyList<zAircraft> clonedList = new MyList<zAircraft>(list);
                Console.WriteLine("Список склонирован");
                return clonedList;
            }
            catch
            {
                Console.WriteLine("Список пуст");
                return new MyList<zAircraft>();
            }
        }
    }
}