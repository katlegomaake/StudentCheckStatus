using System;
using System.Text.RegularExpressions;

public class Student
{
    public string Name { get; }
    public int Marks { get; private set; }
    public string FinalGrade { get; private set; }

    public Student(string name, int marks)
    {
        Name = name;
        Marks = 0; // Initialize Marks with a default value
        FinalGrade = ""; // Initialize FinalGrade with a default value
        SetMarks(marks);
    }

    public void SetMarks(int marks)
    {
        if (marks < 0 || marks > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(marks), "Marks must be between 0 and 100.");
        }

        Marks = marks;

        if (marks < 60)
        {
            FinalGrade = "Failed";
        }
        else if (marks >= 60 && marks <= 65)
        {
            FinalGrade = "Supplementary Exam";
        }
        else if (marks >= 70 && marks <= 80)
        {
            FinalGrade = "Distinction";
        }
        else if (marks >= 81 && marks <= 90)
        {
            FinalGrade = "Distinction A";
        }
        else
        {
            FinalGrade = "Outstanding";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the student's name: ");
        string name = Console.ReadLine();

        int marks = 0;
        do
        {
            Console.WriteLine("Enter the student's marks (out of 100): ");
            string input = Console.ReadLine();
            if (input != null && Regex.IsMatch(input, @"^\d+$"))
            {
                marks = Convert.ToInt32(input);
                if (marks < 0 || marks > 100)
                {
                    Console.WriteLine("Marks must be between 0 and 100.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (marks < 0 || marks > 100);

        if (name != null)
        {
            Student student = new Student(name, marks);

            Console.WriteLine($"Student {student.Name} has achieved a grade of {student.FinalGrade}.");
        }
        else
        {
            Console.WriteLine("Invalid name. Exiting program.");
        }

        Console.ReadLine(); // To keep the console window open
    }
}
