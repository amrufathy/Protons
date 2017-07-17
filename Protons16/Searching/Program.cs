using System;

namespace Searching
{
    internal class Program
    {
        /* binary search algorithm (iterative implementation)
         * search for a number in an array
         * returns index in array if found
         * returns -1 if number not found
         * takes O(log n) time
         */

        private static int BinarySearch(int[] array, int target)
        {
            // use BigInteger or double if necessary
            int low = 0;
            int high = array.Length;

            while (low < high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == target)
                    return mid;
                else if (array[mid] < target)
                    low = mid + 1;
                else
                    high = mid;
            }

            return -1;
        }

        /* binary search algorithm (recursive implementation)
         * search for a number in an array
         * returns index in array if found
         * returns -1 if number not found
         * takes O(log n) time
         */

        private static int BinarySearch(int[] array, int target, int low, int high)
        {
            // use BigInteger or double if necessary
            if (low < high)
            {
                int mid = (low + high) / 2;

                if (array[mid] == target)
                    return mid;
                else if (array[mid] < target)
                    return BinarySearch(array, target, mid + 1, high);
                else
                    return BinarySearch(array, target, low, mid);
            }

            return -1;
        }

        /* linear search algorithm (iterative implementation)
         * search for a number in an array
         * returns index in array if found
         * returns -1 if number not found
         * takes O(n) time
         */

        private static int linearSearch(int[] array, int target)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                if (array[i] == target)
                    return i;
            }

            return -1;
        }

        /* Remember when using doubles, don't use '==' operator
         * instead, check that the difference between values is
         * very small
         * ex: Math.Abs(target - array[index]) < 0.00001
         */

        private static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };
            int target = 5;
            int index = BinarySearch(array, target);
            // int index = BinarySearch(array, target, 0, array.Length);
            // int index = linearSearch(array, target);

            if (index == -1)
            {
                Console.WriteLine("Target not found");
            }
            else
            {
                Console.WriteLine("Target is at " + index);
            }
        }
    }
}