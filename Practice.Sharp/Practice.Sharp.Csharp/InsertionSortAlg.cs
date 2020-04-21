using System;

namespace Practice.Sharp.Csharp
{
    /// <summary>
    /// Complexity O(n²)
    /// </summary>
    public static class InsertionSortAlg
    {
        public static int[] InsertionSort(this int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                while(i > 0 && array[i] < array[i -1])
                {
                    var tmp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = tmp;
                    i -= i;
                }
            }

            return array;
        }
    }
}
