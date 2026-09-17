using System;
using System.IO;

class Program
{
    private static string filePath = "notes.txt";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Simple Notes App ===");
            Console.WriteLine("1. View Notes");
            Console.WriteLine("2. Add Note");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewNotes();
                    break;
                case "2":
                    AddNote();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ViewNotes()
    {
        Console.Clear();
        Console.WriteLine("=== Your Notes ===");
        
        if (File.Exists(filePath))
        {
            string[] notes = File.ReadAllLines(filePath);
            if (notes.Length == 0)
            {
                Console.WriteLine("No notes found.");
            }
            else
            {
                for (int i = 0; i < notes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {notes[i]}");
                }
            }
        }
        else
        {
            Console.WriteLine("No notes file found yet.");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    private static void AddNote()
    {
        Console.Clear();
        Console.WriteLine("=== Add New Note ===");
        Console.Write("Enter your note: ");
        string note = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(note))
        {
            File.AppendAllText(filePath, note + Environment.NewLine);
            Console.WriteLine("Note saved successfully!");
        }
        else
        {
            Console.WriteLine("Note cannot be empty.");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }
}