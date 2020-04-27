using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class Validators
    {
        public static bool IsInRange(this int num, int min, int max)
        {
            return num >= min && num <= max;
        }
    }
}
