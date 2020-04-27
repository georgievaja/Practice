using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class FrogJump
    {
        public static int CountJumps(int start, int end, int jump)
        {
            var diff = end - start;
            if (diff == 0) return 0;
            if (diff % jump == 0) return diff / jump;

            return diff / jump + 1;
        }
    }
}
