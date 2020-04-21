using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Practice.Sharp.Csharp
{
    /// <summary>
    /// Complexity O(n lg n)
    /// </summary>
    public static class MergeSortAlg
    {
        public static int[] MergeSort(this int[] unsorted, int beginning, int end)
        {
            if (beginning < end) 
            {
                var middle = (beginning + end) / 2;
                MergeSort(unsorted, beginning, middle);
                MergeSort(unsorted, middle + 1, end);
                return Merge(unsorted, beginning, middle, end);
            }

            return unsorted;
        }

        private static int[] Merge(int[] arr, int beginning, int middle, int end)
        {
            var subArray1Length = middle - beginning + 1;
            var subArray2Length = end - middle;

            var left = new int[subArray1Length];
            var right = new int[subArray2Length];

            for (var ii = 0; ii < subArray1Length; ii++)
            {
                left[ii] = arr[beginning + ii];
            }

            for (var jj = 0; jj < subArray2Length; jj++)
            {
                right[jj] = arr[middle + jj + 1];
            }


            var i = 0;
            var j = 0;

            for (var k = beginning; k <= end; k++)
            {
                if (i < left.Length && j < right.Length)
                {
                    if (left[i] <= right[j])
                    {
                        arr[k] = left[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = right[j];
                        j++;
                    }
                }
                else if (i < left.Length)
                {
                    arr[k] = left[i];
                    i++;
                }
                else if (j < right.Length)
                {
                    arr[k] = right[j];
                    j++;
                }
            }

            return arr;
        }
    }
}
