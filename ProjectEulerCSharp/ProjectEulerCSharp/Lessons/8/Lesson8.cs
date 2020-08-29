using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerCSharp
{
    public class Lesson8 : Lesson
    {

        public Lesson8(int number) : base(number)
        {
        }

        /// <summary>
        /// The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
        /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
        /// </summary>
        public override void Solve()
        {
            base.Solve();
            Int64 largestProduct = 0;
            Int64 currentProduct = 0;
            int series = 13;
            //List<int> inputDataAsInt = InputData.Select(x => int.Parse(x.ToString())).ToList();

            for (int idx = 0; idx < InputData.Count - series; idx++)
            {
                if (currentProduct == 0)
                {
                    currentProduct = CalculateFirstProduct(idx, series, InputData);
                    idx += (series -1);
                }
                else
                {
                    int lastPos = (idx - series);
                    int nextPos = idx;
                    
                    //Console.WriteLine($"Removing [{lastPos}]{InputData[lastPos]}, multiplying on [{nextPos}]{InputData[nextPos]}");
                    if (InputData[nextPos] == 0 || InputData[lastPos] == 0)
                    {
                        currentProduct = 0;
                        continue;
                    }
                    currentProduct /= InputData[lastPos];
                    currentProduct *= InputData[nextPos];
                }
                //Console.WriteLine($"Current product is {currentProduct}");
                if (currentProduct > largestProduct)
                {
                    largestProduct = currentProduct;
                    //Console.WriteLine($"New largest product {largestProduct}");
                }
            }
            base.Solved(largestProduct.ToString());
        }

        private Int64 CalculateFirstProduct(int position, int series, List<int> range)
        {
            //product is equal to the first number
            Int64 product = range[position];
            //Console.WriteLine($"Starting number is [{position}]{range[position]}");
            if (range[position] == 0)
                return 0;

            //go up from the starting position, and times on the adjacent numbers.
            for (int idx = position; idx < (position+series)-1; ++idx)
            {

                if (range[idx] == 0)
                {
                    //Console.WriteLine($"Detected a zero [{idx}]{range[idx]}");
                    return 0;
                }

                product *= range[idx + 1];
                //Console.WriteLine($"Number to multiply on was {range[idx + 1]},previous was {range[idx]} current product {product}");
            }

            return product;
        }

        private int CalculateProduct(int offSet, int position, int series, int product, List<int> range)
        {
            if (range[offSet + position + 1] == 0)
                return product;

            if (position == 0)
            {
                int prod1 = range[offSet + position] * range[offSet + position + 1];
                //Console.WriteLine($"{range[offSet + position]} * {range[offSet + position + 1]} = {prod1}");
                return CalculateProduct(offSet, ++position, series, prod1, range);
            }
            if (position < series - 1)
            {
                int prod = product * range[offSet + position + 1];
                //Console.WriteLine($"{product} * {range[offSet + position + 1]} = {prod}");
                return CalculateProduct(offSet, ++position, series, prod, range);
            }
            return product;

        }
    }
}
