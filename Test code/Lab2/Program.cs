using System;
using System.Diagnostics;
using Sortingoperations_library;

namespace Lab_02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int ID = 0;
                int ID_copy = 0;
                int[] _array = new int[0];
                int[] _copyarray = new int[0];
                Stopwatch stopwatch = new Stopwatch(); //cекундомер
                ConsoleKeyInfo K;
                do
                {
                    #region  Interface
                    Console.Clear(); //очистка экрана перед выводом меню
                    Console.WriteLine("1.Создать массив");
                    Console.WriteLine("2.Вывести исходный массив");
                    Console.WriteLine("3.Сортировка способ 1");
                    Console.WriteLine("4.Сортировка способ 2");
                    Console.WriteLine("5.Вывести отсортированный массив");
                    Console.WriteLine("Esc. Выход из программы");
                    #endregion

                    K = Console.ReadKey(); //считывание кода вводимой клавиши
                    switch (K.Key)
                    {
                        /*Кейс для создания массива*/
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:// если нажата клавиша с цифрой 1
                            {
                                Console.WriteLine("\nЗадайте размер массива:");
                                int n = 0;
                                bool n_t = int.TryParse(Console.ReadLine(), out n);

                                if (n_t)
                                {
                                    if (n < 0) { Console.WriteLine("Размер массива не может быть равен нулю"); }
                                    else
                                    {
                                        /*Вводится система ID для отслеживания принадлежности
                                         отсортированного массива к исходному*/
                                        ID = Sorting.ArrayID();
                                        _array = Sorting.Input(n);
                                        break;
                                    }
                                }
                                else { Console.WriteLine("неверный тип размера массива"); }
                                break;
                            }

                        /*Кейс вывода исходного массива*/
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:// если нажата клавиша с цифрой 2
                            {
                                if (_array.Length != 0)
                                {
                                    Console.WriteLine("\nИскходный массив");
                                    Console.WriteLine(Sorting.Output(_array));
                                }
                                else { Console.WriteLine("Нет готового массива"); }
                                break;
                            }

                        /*Кейс для сортировкии копии исходного массива методом вставки*/
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:// если нажата клавиша с цифрой 3
                            {
                                if (_array.Length != 0)
                                {
                                    ID_copy = ID;
                                    Console.WriteLine("\nСортировка методом вставки");
                                    _copyarray = Sorting.CopyArray(_array);

                                    stopwatch.Start();
                                    Sorting.InsertMethod(_copyarray);
                                    stopwatch.Stop();
                                    Console.WriteLine($"Время выполнения сортировки: {stopwatch.Elapsed.TotalMilliseconds} мс");
                                }
                                else { Console.WriteLine("Нет массива для сортировки"); }
                                break;
                            }

                        /*Кейс для сортировки копии исхоного массива методом слияния*/
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:// если нажата клавиша с цифрой 4
                            {
                                if (_array.Length != 0)
                                {
                                    ID_copy = ID;
                                    Console.WriteLine("\nСортировка методом слияния");
                                    _copyarray = Sorting.CopyArray(_array);

                                    stopwatch.Start();
                                    Sorting.MergeMethod(_copyarray);
                                    stopwatch.Stop();
                                    Console.WriteLine($"Время выполнения сортировки: {stopwatch.Elapsed.TotalMilliseconds} мс");
                                }
                                else { Console.WriteLine("Нет массива для сортировки"); }
                                break;
                            }

                        /*Кейс для вывода отсортированного массива*/
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:// если нажата клавиша с цифрой 5
                            {
                                if (_copyarray.Length != 0 && ID_copy == ID)
                                {
                                    Console.WriteLine("\n" + Sorting.Output(_copyarray));
                                }
                                else
                                { Console.WriteLine("\nМассив не был отсортирован"); }

                                break;
                            }
                        default: break;
                    }
                    // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                    System.Threading.Thread.Sleep(2000); // 2,6сек.
                }
                while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }

}

