using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class Nesting
    {
        public static int CheckSingleNesting(string s)
        {
            var stack = new Stack<char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(s[i]);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count == 0) return 0;

                    var lastOpening = stack.Pop();
                    if (lastOpening != '(')
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

            return stack.Count == 0 ? 1 : 0;
        }
        public static int CheckMultipleNesting(string s)
        {
            var stack = new Stack<char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (IsOpening(s[i]))
                {
                    stack.Push(s[i]);
                }

                if (IsClosing(s[i]))
                {
                    if (stack.Count == 0) return 0;

                    var lastOpening = stack.Pop();
                    if (!IsMatching(lastOpening, s[i]))
                    {
                        return 0;
                    }
                }
            }

            return stack.Count == 0 ? 1 : 0;
        }

        public static bool IsMatching(char opening, char closing)
        {
            var close = ' ';
            switch (opening)
            {
                case '[':
                    close = ']';
                    break;
                case '(':
                    close = ')';
                    break;
                case '{':
                    close = '}';
                    break;
            }

            return closing == close;
        }

        public static bool IsOpening(char s)
        {
            var opening = new List<char> { '[', '(', '{' };
             return opening.Contains(s);
        }

        public static bool IsClosing(char s)
        {
            var closing = new List<char> { ']', ')', '}' };
            return closing.Contains(s);
        }
    }
}
