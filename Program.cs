using System;
using System.Linq;

namespace MyprojecsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] InputArr=new int []{2,4,6,8,10,12};
            foreach(var i in ArrayHelper<int>.Slice(InputArr,1,5))
            {
                System.Console.WriteLine(i);
            }
            Console.WriteLine($"Удаленный элемент массив:  {ArrayHelper<int>.Pop(ref InputArr)}");
            Console.WriteLine($"Добавлено еще элемент с конца массива!\nДлина обновленный массив:  {ArrayHelper<int>.Push(ref InputArr,15)}");
            Console.WriteLine($"Удаленный элемент массив:  {ArrayHelper<int>.Shift(ref InputArr)}");
            Console.WriteLine($"Добавлено еще элемент с началого массива!\nДлина обновленный массив:  {ArrayHelper<int>.UnShift(ref InputArr,34)}");
            Console.ReadKey();
        }
    }
    static class ArrayHelper<T>
    {
        public static T Pop(ref T[] Arr)
        {
            int IndexRemoteElement = Arr.Length - 1;
            T RemoteElement = Arr[IndexRemoteElement];
            Arr = Arr.Where((item, index) => index != IndexRemoteElement).ToArray();
            return RemoteElement;
        }
        public static int Push(ref T[] Arr, T Element)
        {
            Arr = Arr.Concat(new T[] { Element }).ToArray();
            int LengthUpdatedArray = Arr.Length;
            return LengthUpdatedArray;
        }
        public static T Shift(ref T[] Arr)
        {
            T RemoteElement = Arr[0];
            Arr = Arr.Where((item, index) => index != 0).ToArray();
            return RemoteElement;
        }
        public static int UnShift(ref T[] Arr, T Element)
        {
            var NewArray = new T[Arr.Length + 1];
            Array.Copy(Arr, 0, NewArray, 1, Arr.Length);
            int LengthUpdatedArray = NewArray.Length;
            return LengthUpdatedArray;
        }
        public static T[] Slice(T[] Arr, int BeginIndex, int EndIndex)
        {
            T[] Arr2 = new T[EndIndex-BeginIndex];
            for (int i = 0; i < Arr2.Length; i++)
            {
                Arr2[i] = Arr[BeginIndex];
                BeginIndex++;
            }

            return Arr2;
        }
    }
}
//Это не все...