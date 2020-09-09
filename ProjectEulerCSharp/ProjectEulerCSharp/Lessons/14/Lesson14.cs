using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerCSharp.Lessons
{
    public class Lesson14 : Lesson
    {
        public Lesson14(int number) : base (number)
        {

        }


        /// <summary>
        /// The following iterative sequence is defined for the set of positive integers:
        /// n → n/2 (n is even)
        /// n → 3n + 1 (n is odd)
        /// Which starting number, under one million, produces the longest chain?
        /// </summary>
        public override void Solve()
        {
            base.Solve();
            //first we solve without any optimisations
            int maxTerms = 0;
            int numberOfGreatestTerms = 0;
            for (int idx = 1; idx <= 1000000; ++idx)
            {
                var terms = FindTerms(idx);
                if(terms > maxTerms)
                {
                    numberOfGreatestTerms = idx;
                    maxTerms = terms;
                }
            }

            base.Solved(numberOfGreatestTerms.ToString());
        }

        private int FindTerms(long startingNumber)
        {
            //start from 1 as we never take into account 1 in the following loop.
            int terms = 1;
            while(startingNumber > 1)
            {
                //Console.Write($"{startingNumber} ->");
                //even
                if (startingNumber % 2 == 0)
                {
                    startingNumber /= 2;
                    //Console.Write($" Even ");
                    
                } 
                else
                {
                    startingNumber *= 3;
                    startingNumber++;
                    //Console.Write($" Odd ");
                }
                terms++;
            }
            
           // Console.Write($"Found {terms} terms \n");
            return terms;
        }
    }
}
