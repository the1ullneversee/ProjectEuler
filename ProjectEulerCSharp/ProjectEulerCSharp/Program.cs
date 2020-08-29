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
            Lesson lesson = new Lesson12(12);
            lesson.Solve();
        }
    }
}
