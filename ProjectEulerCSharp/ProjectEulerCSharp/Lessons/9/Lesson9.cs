using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerCSharp.Lessons
{
    public class Lesson9 : Lesson
    {
        public Lesson9(int number) : base(number)
        {

        }
        const int range = 1000;
        public override void Solve()
        {
            string result = "";
            base.Solve();
            result = FindResult(result);
            base.Solved(result);
        }

        private string FindResult(string result)
        {
            for (int a = 0; a < (range/3); ++a)
            {
                for (int b = (a + 1); b < (range/2); ++b)
                {
                    int c = range - a - b;
                    if (a*a + b*b == c*c)
                    {
                        if (a + b + c == 1000)
                            return $"{(a*b*c)}";
                    }
                    
                }
            }

            return result;
        }
    }
}
