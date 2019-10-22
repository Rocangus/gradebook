using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");

            Console.WriteLine("Please enter a grade (say 72.4) and hit enter to put it into the grade book. To stop entering, please write 'q' and hit enter.");
            var input = Console.ReadLine();
            while (input != "q")
            {
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    input = Console.ReadLine();
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }
    }
}
