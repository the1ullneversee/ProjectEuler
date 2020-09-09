using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerCSharp.Lessons
{
    public class Lesson12 : Lesson
    {
        public Lesson12(int lessonNumber) : base(lessonNumber)
        {


        }

        public static long Solution(string s)
        {
            char[] chars = s.ToCharArray();
            long max = 0;
            long tempMax = 0;
            List<char> pattern = new List<char>();
            long[] prices = new long[5];
            //go through each character and check the pattern ahead
            for(int idx = 0; idx < chars.Length; ++idx)
            {
                int counter = idx + 1;
                while (counter < chars.Length)
                {
                    char current = chars[counter];
                    if (!Exists(current, pattern))
                    {
                        Console.Write($"[{current}]");
                        pattern.Add(current);
                        tempMax++;
                        counter++;
                        if (tempMax > max)
                        {
                            max = tempMax;

                        }
                    }
                    else
                    {
                        tempMax = 0;
                        pattern.Clear();
                        break;
                    }
                   
                }
            }
            return max;
        }

        private static bool Exists(char c, List<char> pattern)
        {
            if (pattern.Count == 0)
                return false;

            foreach(char a in pattern)
            {
                if ((c ^ a) == 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// What is the value of the first triangle number to have over five hundred divisors?
        /// </summary>
        public override void Solve()
        {
            base.Solve();
            int divisorsGoal = 500;
            Int64 currentTriangle = 1;
            Int64 startTriangle = 1;
            int currentMaxDivisors = 0;

            while (currentMaxDivisors <= divisorsGoal)
            {
                int tempDivisorCount = FindDivisors(currentTriangle);

                if (tempDivisorCount > currentMaxDivisors)
                {
                    //Console.WriteLine($"New max divisors found: {tempDivisorCount}");
                    currentMaxDivisors = tempDivisorCount;
                }
                if (currentMaxDivisors >= divisorsGoal)
                {
                    break;
                }
                currentTriangle += (startTriangle + 1);
                startTriangle++;
            }

            base.Solved("");
        }

        private int FindDivisors(Int64 num)
        {
            int divisors = 1;
            Int64 potentialFactor = num / 2;
            Int64 sqRoot = (int)Math.Sqrt(num);
            List<Int64> factors = new List<Int64>();
            for(int idx = 1; idx < sqRoot; ++idx)
            {
                if(num % idx == 0)
                {
                    factors.Add(idx);
                    divisors++;
                    if(num != num/idx)
                    {
                        factors.Add(num/idx);
                        divisors++;
                    }
                }
            }
            return factors.Count;
          
        }
    }
}
