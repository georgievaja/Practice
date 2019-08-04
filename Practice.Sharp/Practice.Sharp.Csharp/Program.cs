using System;
using System.Collections.Generic;
using static Practice.Sharp.Csharp.BinaryGap;

namespace Practice.Sharp.Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new int[] { 9, 529, 51272, 15, 53, 2147483647 };

            foreach (var data in testData)
            {
                var gap = GetBinaryGap(data);
                Console.WriteLine($"{gap}, {data}");
            }
        }
    }
}
