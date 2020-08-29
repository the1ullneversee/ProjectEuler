using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerCSharp.Lessons
{
    public class Lesson10 : Lesson
    {
        public Lesson10(int number): base(number)
        {

        }

        /// <summary>
        /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        /// Find the sum of all the primes below two million.
        /// Will be using the Sieve of Eratosthenes.
        /// </summary>
        /// 1. Create a list of consecutive integers from 2 through n: (2, 3, 4, ..., n).
        //  2. Initially, let p equal 2, the smallest prime number.
        //  3. Enumerate the multiples of p by counting in increments of p from 2p to n, and mark them in the list (these will be 2p, 3p, 4p, ...; the p itself should not be marked).
        //  4. Find the smallest number in the list greater than p that is not marked.If there was no such number, stop.Otherwise, let p now equal this new number(which is the next prime), and repeat from step 3.
        //  5. When the algorithm terminates, the numbers remaining not marked in the list are all the primes below n.
        public override void Solve()
        {
            base.Solve();
            int start = 2;
            int upperBound = 2000000;
            //int[] primes = new int[upperBound];
            List<int> primes = new List<int>();
            bool primeFound = false;
            string result = "";
            Int64 sum = 0;
            for (int idx = start; idx < upperBound; ++idx)
            {
                if (idx % idx == 0)
                {
                    primeFound = true;
                    foreach (int prime in primes)
                    {
                        if (idx % prime == 0)
                        {
                            primeFound = false;
                            break;
                        }
                    }
                    if (primeFound)
                    {
                        sum += idx;
                        //Console.WriteLine($"{idx}");
                        primes.Add(idx);
                    }
                }
            }
            base.Solved($"Sum {sum}");
        }

        private bool IsPrime(int number)
        {
            if (number / number == 0)
                return true;
            else
                return false;
        }
    }
}
