using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace advanced03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };
            //Exercise 1: Student Grade Manager
            //Print the collection, Count, first and last grade
            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine("Count: " + grades.Count);
            Console.WriteLine("First Grade: " + grades[0]);
            Console.WriteLine("Last Grade: " + grades[grades.Count - 1]);

            //Sort the grades ascending, then print
            grades.Sort();
            Console.WriteLine("Sorted Grades: " + string.Join(", ", grades));
            //Get the first grade above 90
            int firstGradeAbove90 = grades.FirstOrDefault(g => g > 90);
            Console.WriteLine("First Grade Above 90: " + firstGradeAbove90);
            //Get all grades below 75(failing grades)
            List<int> failingGrades = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing Grades: " + string.Join(", ", failingGrades));
            //Remove all failing grades(below 75)
            grades.RemoveAll(g => g < 75);
            Console.WriteLine("Grades after removing failing grades: " + string.Join(", ", grades));
            //Check if any grade equals 100
            bool hasPerfectScore = grades.Any(g => g == 100);
            Console.WriteLine("Has Perfect Score: " + hasPerfectScore);
            //Create a List<string> where each grade becomes "Grade: X"
            List<string> gradeStrings = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine("Grade Strings: " + string.Join(", ", gradeStrings));





        }
    }
}
