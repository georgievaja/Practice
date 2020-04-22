using System;

namespace Practice.Sharp.Csharp.Sorts.Comparision
{
    /// <summary>
    /// Complexity O(n²)
    /// </summary>
    public static class InsertionSortAlg
    {
        public static void InsertionSort(this int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                while (i > 0 && array[i] < array[i - 1])
                {
                    var tmp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = tmp;
                    i -= i;
                }
            }
        }
    }
}
