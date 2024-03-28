using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace Sortingoperations_library
{
    public class Sorting
    {
        #region Interface integration
        /// <summary>
        /// Метод заполнения массива с задаваемым размером
        /// </summary>
        /// <param name="n"> размер массива </param>
        /// <returns></returns>
        public static int[] Input(int n)
        {
            int[] numbers = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rnd.Next(-1000, 1000);
            return numbers;
        }

        public static int[] CopyArray(int[] arraytocopy)
        {
            int[] _copyarray = new int[arraytocopy.Length];
            Array.Copy(arraytocopy, _copyarray, arraytocopy.Length);
            return _copyarray;
        }

        /// <summary>
        /// Формирование строки из одномерного массива
        /// </summary>
        /// <param name="array">строка</param>
        public static string Output(int[] array)
        {
            string s = String.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                s = s + array[i].ToString() + " ";
            }
            s = s + "\n";
            return s;
        }

        /// <summary>
        /// метод присваивания уникального ID
        /// </summary>
        /// <returns></returns>
        public static int ArrayID()
        {
            int ID = 0;
            Random rnd = new Random();
            ID = rnd.Next(1000, 9999);
            return ID;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// сортировка методом вставки 
        /// </summary>
        /// <param name="unsorted"> не отсортированный массив чисел </param>
        public static void InsertMethod(int[] unsorted)
        {
            int N = unsorted.Length; //длина изначального массива
            for (int i = 1; i < N; i++) //начиная с первого элемента мы условно делим массив на сортированную и не сортированную части
            {
                int _currentelement = unsorted[i]; //текущий рассматриваемый элемент
                int j = i - 1;

                #region большой некрасивый комментарий
                /// берем рассматриваемый элемент и смотрим
                /// соблюдается ли условие сортировки в массиве,
                /// если элемент будет в позиции j+1
                /// если рассматриваемый элемент оказывается меньше 
                /// предыдущего, то мы двигаем элементы в право до тех пор
                /// пока _currentelement в позиции j+1 не будет удовлетоворять отсорт. позиции
                #endregion
                while (j >= 0 && unsorted[j] > _currentelement)
                {
                    unsorted[j + 1] = unsorted[j]; //сдвиг в право
                    j -= 1;
                }
                unsorted[j + 1] = _currentelement;
            }
        }
        #endregion

        #region Merge method
        /// <summary>
        /// Реализация сортировки методом слияния
        /// </summary>
        /// <param name="unsorted">не отсортированный массив чисел</param>
        public static void MergeMethod(int[] unsorted)
        {
            int N = unsorted.Length; //длина изначального массива
            if (N <= 1) { return; } //мы будем делить наш массив до того, пока он не будет разделенн до единичных массивов

            int mid = N / 2;
            
            /*левый куос - половина от разделяемого (до середины)
            правый кусок - другая половина от разделяемого (после середины)*/
            int[] leftArray = new int[mid];
            int[] rightArray = new int[N - mid];

            int i = 0; //left array index pos
            int j = 0; //right array index pos

            /* бежим по индексам делимого массива
            первую половину i-ых элементов гоним в левый
            вторую половину i-ых элементов гоним в правый
            j - нужен чтобы правые шли с 0 индекса*/
            for (; i < N; i++)
            {
                if (i < mid) { leftArray[i] = unsorted[i]; }
                else { rightArray[j] = unsorted[i]; j++; }
            }

            /*уходим в рекурсию для деления массива до состояния одиночных элементов
            через деление каждой половины*/
            MergeMethod(leftArray);
            MergeMethod(rightArray);
            Merge(leftArray, rightArray, unsorted);
        }

        /// <summary>
        /// реализация слияния одинарных элементов
        /// </summary>
        /// <param name="left">левая половина делимого массива</param>
        /// <param name="right">правая половина делимого массива</param>
        /// <param name="unsorted">делимый массив</param>
        static void Merge(int[] left, int[] right, int[] unsorted)
        {
            /*левая половина делимого в моменте массива равняется его половине
            а правая всему остальному за ее исключением, так мы исключаем 
            ситуации с нечетным кол-вом элементов*/
            int leftSize = unsorted.Length / 2;
            int rightSize = unsorted.Length - leftSize;

            int i_pos = 0, l_pos = 0, r_pos = 0; //индексы для левой стороны, правой стороны и рассматриваемого массива

            /*рассматривая разделенный массив, мы смотрим на первые индексы
            его левой и правой стороны. На первую позицию мы записываем наименьший элемент*/
            while (l_pos < leftSize && r_pos < rightSize) 
            {
                if (left[l_pos] < right[r_pos])
                {
                    unsorted[i_pos] = left[l_pos];
                    i_pos++;
                    l_pos++;
                }
                else
                {
                    unsorted[i_pos] = right[r_pos];
                    i_pos++;
                    r_pos++;
                }
            }
            
            /*По истечению первого While должно получится так, что либо прававя
            либо левая сторона вышла по индексу за условие ИНДЕКС < РАЗМЕР
            значит мы идем по отсавшимся элементам и берем наименьший из них*/
            while (l_pos < leftSize) 
            {
                unsorted[i_pos] = left[l_pos];
                i_pos++;
                l_pos++;
            }

            while (r_pos < rightSize)
            {
                unsorted[i_pos] = right[r_pos];
                i_pos++;
                r_pos++;
            }
        }
        #endregion
    }
}


