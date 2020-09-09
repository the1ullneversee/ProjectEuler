using ProjectEulerCSharp.Lessons;
using System;
using System.IO;

namespace ProjectEulerCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Lesson lesson = new Lesson14(14);
            lesson.Solve();
        }
    }
}
