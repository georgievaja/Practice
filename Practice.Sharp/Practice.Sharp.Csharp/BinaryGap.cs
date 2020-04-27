using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class BinaryGapRecursion
    {
        public static int CountBinaryGap(int num)
        {
            if (!num.IsInRange(1, 2147483647)) return -1;

            var binary = RemoveTrailingZeroes(num);

            return Shift(0, binary);
        }

        private static bool AllAreOnes(int num)
        {
            return (((num + 1) & num) == 0) && (num != 0);
        }

        private static int RemoveTrailingZeroes(int num)
        {
            return (num & 1) != 0 ? num : RemoveTrailingZeroes(num >> 1);
        }

        private static int Shift(int steps, int num)
        {
            return AllAreOnes(num) ? steps : Shift(steps + 1, num | num << 1);
        }
    }

    public static class BinaryGapIteration
    {
        public static int CountBinaryGap(int num)
        {
            if (!num.IsInRange(1, 2147483647)) return -1;

            var binary = RemoveTrailingZeroes(num);

            return Shift(0, binary);

        }

        private static bool AllAreOnes(int num)
        {
            return (((num + 1) & num) == 0) && (num != 0);
        }

        private static int RemoveTrailingZeroes(int num)
        {
            while (true)
            {
                if ((num & 1) != 0) return num;
                num >>= 1;
            }
        }

        private static int Shift(int steps, int num)
        {
            while (true)
            {
                if (AllAreOnes(num)) return steps;
                steps += 1;
                num |= num << 1;
            }
        }
    }
}
