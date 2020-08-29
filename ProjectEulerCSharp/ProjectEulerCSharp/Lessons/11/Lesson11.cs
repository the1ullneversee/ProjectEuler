using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEulerCSharp.Lessons
{
    public class Lesson11 : Lesson
    {
        public Lesson11(int lessonNumber) : base(lessonNumber)
        {
        }
        
        private int[][] InputArray = new int[20][];

        public override void LoadFileData()
        {
            int counter = 0;
            using (StreamReader sr = new StreamReader(InputFilePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var lineChars = line.Split(' ');
                    InputArray[counter] = lineChars.Select(x => int.Parse(x.ToString())).ToArray();
                    counter++;
                }
            }
        }

        /// <summary>
        /// What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
        /// </summary>
        public override void Solve()
        {
            base.Solve();

            Int64 largestProduct = 0;
            Int64 tempProd, tempProd1, tempProd2;

            //rows
            for(int row = 0; row < InputArray.Length; row++)
            {
                //columns
                for (int col = 0; col < InputArray[row].Length; col++)
                {

                    //checking right
                    if (col <= 16)
                    {
                        tempProd = CalculateProduct(InputArray[row][col], InputArray[row][col + 1], InputArray[row][col + 2], InputArray[row][col + 3]);
                        largestProduct = Math.Max(tempProd, largestProduct);
                    }

                    //check down and left
                    if (col >= 4 && row <= 16)
                    {
                        tempProd1 = CalculateProduct(InputArray[row][col], InputArray[row+1][col-1], InputArray[row+2][col-2], InputArray[row+3][col-3]);
                        largestProduct = Math.Max(tempProd1, largestProduct);
                    }

                    //Check down and right
                    if (row <= 16 && col <= 16)
                    {
                        tempProd2 = CalculateProduct(InputArray[row][col], InputArray[row+1][col + 1], InputArray[row+2][col + 2], InputArray[row+3][col + 3]);
                        largestProduct = Math.Max(tempProd2, largestProduct);
                    }
                }


            }
            base.Solved(largestProduct.ToString());
        }

        private Int64 CalculateProduct(Int64 a, Int64 b, Int64 c, Int64 d)
        {
            return a * b * c *d;
        }

       
    }
}
