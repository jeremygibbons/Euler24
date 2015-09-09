using System;
using System.Linq;

namespace Euler24
{
    class Program
    {
        static int[] set;

        static void Main(string[] args)
        {
            set = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int count = 1;

            while (count < 1000000)
            {
                NextPermutation();
                count++;
            }

            Console.WriteLine(IntArrayToString(set));

            Console.ReadLine();
        }

        static bool NextPermutation()
        {
            int  i = set.Length - 1;

            //find pivot: index of first element not in order (smaller than the one before)
            while (i > 0 && set[i - 1] >= set[i])
                i--;

            //there is no next element
            if (i <= 0)
                return false;

            //find the index of the first element that is larger than the pivot
            int j = set.Length - 1;
            while (set[j] <= set[i - 1])
                j--;

            //swap the pivot and the element found above
            int temp = set[i - 1];
            set[i - 1] = set[j];
            set[j] = temp;

            //reverse the part of the array to the right of the pivot to get smallest permutation
            Array.Reverse(set, i, set.Length - i);

            return true;
        }

        static string IntArrayToString(int[] a)
        {
            return string.Join("", a.Select(x => x.ToString()).ToArray());
        } 
    }
}
