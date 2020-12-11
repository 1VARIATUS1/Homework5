using System;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;

            do
            {
                Console.WriteLine("Enter the size of the array (1-10):");
                int.TryParse(Console.ReadLine(), out size);
                if (size < 1 || size > 10)
                    Console.WriteLine("Error input");
            }
            while (size < 1 || size > 10);

            Console.WriteLine("Random array:");
            int[] array = new int[size];
            Random num = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = num.Next(0, 99);
                Console.Write("{0}\t", array[i]);
            }

            bool correctChoose;
            do
            {
                Console.Write("\nChoose sorting:\n1 - Bubble sort\n2 - Bubble sort\n3 - Selection sort\n4 - Insertion sort\n");
                string sort = Console.ReadLine();
                correctChoose = true;
                switch (sort)
                {
                    case "1":
                        Console.WriteLine($"\nBubble sort:");
                        BubbleSort(array);
                        break;
                    case "2":
                        Console.WriteLine($"\nQuick sort:");
                        QuickSort(array, 0, array.Length - 1);
                        for (int i = 0; i < array.Length; i++)
                            Console.Write("{0}\t", array[i]);
                        break;
                    case "3":
                        Console.WriteLine($"\nSelection sort:");
                        SelectionSort(array);
                        break;
                    case "4":
                        Console.WriteLine($"\nInsertion sort:");
                        InsertionSort(array);
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        correctChoose = false;
                        break;
                }              
            }
            while (!correctChoose);

            Console.ReadKey();
        }

        public static int [] QuickSort(int [] array, int left, int right)
        {
            int l = left;
            int r = right;
            int avg = array[(l + r) / 2];
            int temp;
            do
            {
                while (array[l] < avg)
                    ++l;
                while (array[r] > avg)
                    --r;
                if (l <= r)
                {
                    if (l < r)
                    {
                        temp = array[l];
                        array[l] = array[r];
                        array[r] = temp;
                    }
                    ++l;
                    --r;
                }
            }
            while (l <= r);
            if (left < r)
            {
                QuickSort(array, left, r);                
            }
            if (l < right)
            {
                QuickSort(array, l, right);                
            }                           
            return array;
        }
        public static int [] BubbleSort(int [] array)
        {
            
            int temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0}\t", array[i]);
            return array;
            
        }
        public static int [] SelectionSort( int[] array)
        {
            int temp, low;

            for (int i = 0; i < array.Length - 1; i++)
            {
                low = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[low])
                    {
                        low = j;
                    }
                }
                temp = array[low];
                array[low] = array[i];
                array[i] = temp;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0}\t", array[i]);
            return array;

        }
        public static int [] InsertionSort(int [] array)
        {
            int temp;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0}\t", array[i]);
            return array;
        }
    }
}
