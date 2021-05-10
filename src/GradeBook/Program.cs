using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book;

            Console.WriteLine("Would you like to save the grades in file? Type (Y) Yes or (N) No.");
            var answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                Console.WriteLine("Enter the file name");
                var filename = Console.ReadLine();

                book = new DiskBook(filename);
            } else
            {
                book = new InMemoryBook();
            }

            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var statistics = book.GetStatitics();
            ShowStatistics(statistics);
        }

        private static void EnterGrades(IBook book) 
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);

                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ShowStatistics(Statistics statistics)
        {
            Log("The average is", statistics.Average);
            Log("The highest grade is", statistics.High);
            Log("The lowest grade is", statistics.Low);
            Log("The grades number is", statistics.Count);
            Log("The matching letter is", statistics.Letter);
        }

        private static void Log(string message, double parameter)
        {
            Log(message, parameter.ToString());
        }

        private static void Log(string message, char parameter)
        {
            Log(message, parameter.ToString());
        }

        private static void Log(string message, string parameter)
        {
            Console.WriteLine($"{message} {parameter}");
        }

        public static void OnGradeAdded(object sender, EventArgs e) 
        {
            Console.WriteLine("A grade was added");
        }
    }
}
