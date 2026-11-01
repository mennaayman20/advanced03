using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
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

            //Exercise 2: Leaderboard

            //Create a leaderboard that automatically sorts players by score.
            //Add: 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona"
            //Print all entries(they should be sorted by score automatically)
            

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();
            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");

            Console.WriteLine("Leaderboard:");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"Score: {entry.Key}, Player: {entry.Value}");
            }

            //Access the first key and first value
            int firstKey = leaderboard.Keys.First();
            string firstValue = leaderboard.Values.First();
            Console.WriteLine($"First Key: {firstKey}, First Value: {firstValue}");

            //Check if score 500 exists
            bool scoreExists = leaderboard.ContainsKey(500);
            Console.WriteLine($"Score 500 exists: {scoreExists}");

            //Safely get the player with score 999
            string playerWithScore999 = leaderboard.GetValueOrDefault(999, "Player not found");
            Console.WriteLine($"Player with score 999: {playerWithScore999}");

            //Remove the player with score 200 and print the updated list
            leaderboard.Remove(200);
            Console.WriteLine("Leaderboard after removing player with score 200:");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"Score: {entry.Key}, Player: {entry.Value}");
            }


            //Exercise 3: Phone Book
            //Build a phone book application.
            //Create a Collection with 4 contacts(name → phone number)

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Alice", "123-456-7890" },
                { "Bob", "234-567-8901" },
                { "Charlie", "345-678-9012" },
                { "David", "456-789-0123" }
            };
            // Add a new contact using [] syntax (add or update)
            phoneBook["Eve"] = "567-890-1234";
            // Try adding a duplicate using .Add() — catch the exception and print the error
            try
            {
                phoneBook.Add("Alice", "999-999-9999");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            // Try adding a duplicate using .TryAdd() — print whether it succeeded
            bool added = phoneBook.TryAdd("Bob", "888-888-8888");
            Console.WriteLine($"Trying to add duplicate 'Bob': {(added ? "Succeeded" : "Failed")}");
            // Search for a contact that doesn’t exist
            if (!phoneBook.ContainsKey("Frank"))
            {
                Console.WriteLine("Contact 'Frank' does not exist.");
            }
            // Get a contact with a fallback of "Not Found"
            string contact = phoneBook.GetValueOrDefault("Grace", "Not Found");
            Console.WriteLine($"Contact 'Grace': {contact}");
            // Print all Keys on one line, then all Values on another line
            Console.WriteLine("Contacts: " + string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Phone Numbers: " + string.Join(", ", phoneBook.Values));


            //Exercise 4: Unique Email Validator
            //Use Collection to manage unique email addresses.

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine($"Count of unique emails: {emails.Count}");

            // Create two sets
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            // Print the result of: UnionWith, IntersectWith, ExceptWith
            var union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine($"Union: {string.Join(", ", union)}");

            var intersection = new HashSet<int>(setA);
            intersection.IntersectWith(setB);
            Console.WriteLine($"Intersection: {string.Join(", ", intersection)}");

            var difference = new HashSet<int>(setA);
            difference.ExceptWith(setB);
            Console.WriteLine($"Difference: {string.Join(", ", difference)}");

            // Use IsSubsetOf to check if { 1,2} is a subset of Set A
            var subset = new HashSet<int> { 1, 2 };
            Console.WriteLine($"Is {{1,2}} a subset of Set A? {subset.IsSubsetOf(setA)}");

            // Exercise 5: Print Queue Simulator
            //Simulate a printer queue
            //Create a Queue<string> and enqueue 5 documents: "Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg"
            //Print the queue contents and Count
            //Use Peek to see which document will print next(without removing)
            //Process the queue: Dequeue each document and print "Printing: [name]"
            //Try TryDequeue on the now - empty queue — what happens?

            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue contents: " + string.Join(", ", printQueue));
            Console.WriteLine($"Queue Count: {printQueue.Count}");
            string nextDoc = printQueue.Peek();
            Console.WriteLine($"Next document to print: {nextDoc}");

            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {doc}");
            }


            bool success = printQueue.TryDequeue(out string? result);
            Console.WriteLine($"TryDequeue Success? {success}"); // Output: False
            Console.WriteLine($"Result: {result ?? "null"}");     // Output: null





        }
    }
}
