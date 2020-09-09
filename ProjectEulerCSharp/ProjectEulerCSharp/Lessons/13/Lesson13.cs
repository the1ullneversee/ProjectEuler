using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEulerCSharp.Lessons
{
    public class Lesson13 : Lesson
    {
        public Lesson13(int number) : base (number)
        {
        }

        private List<int[]> digits;
        public override void LoadFileData()
        {
            digits = new List<int[]>();
            using (StreamReader sr = new StreamReader(InputFilePath))
            {
                while (!sr.EndOfStream)
                { 
                    var ints = sr.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();

                    digits.Add(ints);
                }
            }
        }

        /// <summary>
        /// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
        /// </summary>
        public override void Solve()
        {
            base.Solve();

            int[] sum = new int[51];
            for (int idx = 0; idx < (digits.Count); ++idx)
            {
                if(idx == 0)
                {
                    sum = (int[])digits[idx].Clone();
                } 
                else
                {
                    sum = LargeNumberAddition(sum, digits[idx]);
                }
                
            }
            string first10AsString = "";
            for(int idx = 0; idx < 10; ++idx)
            {
                first10AsString += sum[idx].ToString();
            }
            base.Solved(first10AsString);
        }

        private int[] LargeNumberAddition(int [] prevSum,int [] num2)
        {
            int[] sum = new int[prevSum.Length];
            int carry = 0;
            int newSum = 0;
            int leastSigNum1 = prevSum.GetUpperBound(0);
            int leastSigNum2 = num2.GetUpperBound(0);
            int mostSigNum2 = num2.GetLowerBound(0);
            int index1 = leastSigNum1;
            int index2 = leastSigNum2;
            int sumIndex = sum.GetUpperBound(0);

            int number2Value = 0;

            while (index1 >= prevSum.GetLowerBound(0))
            {
                if (index2 < mostSigNum2)
                {
                    number2Value = 0;
                }
                else
                {
                    number2Value = num2[index2];
                }
                newSum = prevSum[index1] + number2Value + carry;
                if (newSum > 9)
                {
                    carry = 1;
                    newSum -= 10;

                }
                else
                {
                    carry = 0;
                }

                sum[sumIndex] = newSum;

                index1--;
                index2--;
                sumIndex--;
            }
            if (carry == 1)
            {
                int[] shallow = (int[])sum.Clone();
                sum = new int[(sum.Length + 1)];
                shallow.CopyTo(sum, 1);
                sum[0] = 1;

            }

            return sum;
        }
    }
}
