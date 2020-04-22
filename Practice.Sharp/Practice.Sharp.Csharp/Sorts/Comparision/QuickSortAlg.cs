using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp.Sorts.Comparision
{
    /// <summary>
    /// Complexity O(n²)
    /// </summary>
    public static class QuickSortAlg
    {
        public static void QuickSort(this int[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = Partition(A, left, right);

            if (index != -1)
            {
                A.QuickSort(left, index - 1);
                A.QuickSort(index + 1, right);
            }
        }

        private static int Partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = A[right];    // choose last one to pivot
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    Swap(A, i, end);
                    end++;
                }
            }

            Swap(A, end, right);

            return end;
        }

        private static void Swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
    }
}
