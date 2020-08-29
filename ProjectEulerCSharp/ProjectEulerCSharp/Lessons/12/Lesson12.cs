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

            while(currentMaxDivisors <= divisorsGoal)
            {
                int tempDivisorCount = FindDivisors(currentTriangle);

                if(tempDivisorCount > currentMaxDivisors)
                {
                    //Console.WriteLine($"New max divisors found: {tempDivisorCount}");
                    currentMaxDivisors = tempDivisorCount;
                }
                if(currentMaxDivisors >= divisorsGoal)
                {
                    break;
                }
                currentTriangle += (startTriangle + 1);
                startTriangle++;
            }

            base.Solved(currentTriangle.ToString());
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
