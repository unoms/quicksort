using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoareSort
{
    class Program
    {   /// <summary>
        ///   The algorithm represents a quick sort algorithm 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"> at the first run that is arr.Length - 1</param>
        static void Hoare(int[]arr, int start, int end)
        {
            //Base of the recursion
            if (start == end) return;
            //a pivot or base element. The last one in our algorithm
            int pivot = arr[end];//  int pivot = end;
            //A lower point which represents elements which are less than a pivot element
            int lowerPtr = start; 

            //We loop throuth the given array
            for(int i = start; i <= end - 1; i++) //end - 1 due to the last element is a pivot
            {
                if(arr[i] <= pivot)
                {
                    //We change i-element with the element arr[lowerPtr]
                    int tmp1 = arr[i];
                    arr[i] = arr[lowerPtr];
                    arr[lowerPtr] = tmp1;
                    lowerPtr++;
                }
            }

            //After this step we need to exchange a pivot element with arr[lowerPtr]
            int tmp2 = arr[lowerPtr];
            arr[lowerPtr] = arr[end];
            arr[end] = tmp2;

            //Now we need to start Hoare sort for the left side of the pivot element and the right side of it
            if (lowerPtr > start)
                Hoare(arr, start, lowerPtr - 1);
            if (lowerPtr < end)
                Hoare(arr, lowerPtr + 1, end);
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 100, 23, 0, 5, 1, 4, 2, 3 };

            Hoare(nums, 0, nums.Length - 1);

            foreach (int item in nums)
                Console.WriteLine(item);
        }
    }
}
