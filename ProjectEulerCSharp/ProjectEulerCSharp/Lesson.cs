using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEulerCSharp
{
    public class Lesson
    {
        private int _lessonNumber;
        private string _inputFilePath;
        private List<int> _inputData;
        private bool _readInputData;

        public int LessonNumber { get => _lessonNumber; set => _lessonNumber = value; }
        public string InputFilePath { get => _inputFilePath; set => _inputFilePath = value; }
        public List<int> InputData { get => _inputData; set => _inputData = value; }
        public bool OverrideInputRead { get => _readInputData; set => _readInputData = value; }

        private Stopwatch stopwatch;

        public Lesson(int number)
        {
            LessonNumber = number;
            InputFilePath = Directory.GetCurrentDirectory() + @$"\Lessons\{LessonNumber}\input.txt";
            stopwatch = new Stopwatch();
            if (File.Exists(InputFilePath))
                LoadFileData();
        }

        public virtual void Solve() {
            stopwatch.Start();
            Console.WriteLine($"============= Solving Lesson {LessonNumber} =============");
        }

        public void Solved(string result)
        {
            stopwatch.Stop();
            Console.WriteLine($"============= Solved Lesson {LessonNumber} in {stopwatch.Elapsed} with result {result} =============");
        }

        public virtual void LoadFileData()
        {
            InputData = new List<int>();
            using(StreamReader sr = new StreamReader(InputFilePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var characters = line.ToCharArray();
                    InputData.AddRange(characters.Select(x => int.Parse(x.ToString())));
                }
            }
        }
    }
}
