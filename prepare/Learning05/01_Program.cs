using System;
using System.Globalization;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Learning05
{
    class Program
    {
        static void Main(string[] args)
        {
            // - - - [PREP: start] - - -

            // Instantiate the shapes and set their properties
            Square sShape_1 = new Square("1", "Red", 5);                    // Shape: Square 1
            Rectangle rShape_1 = new Rectangle("1", "DarkMagenta", 10, 5);      // Shape: Rectangle 1
            Circle cShape_1 = new Circle("1", "Blue", 5);                   // Shape: Circle 1

            Square sShape_2 = new Square("2", "Red", 8);                    // Shape: Square 1
            Rectangle rShape_2 = new Rectangle("2", "DarkMagenta", 8, 7);      // Shape: Rectangle 1
            Circle cShape_2 = new Circle("2", "Blue", 15);                   // Shape: Circle 1

            // Append the shapes to a list
            List<Shape> shapes = new List<Shape>();
            shapes.Add(sShape_1); // 1s
            shapes.Add(rShape_1);
            shapes.Add(cShape_1);
            shapes.Add(sShape_2); // 2s
            shapes.Add(rShape_2);
            shapes.Add(cShape_2);

            // - - - [PREP: end] - - -

            // - - - [OUTPUT: start] - - -

            Console.Clear();
            Console.WriteLine($"Shape Area:"); // Header
            ShortPause(700);

            // Iterate through the list and display their areas
            foreach (Shape shape in shapes)
            {
                DisplayArea(shape);
                ShortPause(300);
            }

            Console.Write("\n");

            // - - - [OUTPUT: end] - - -
        }

        // UTILITY METHODS

        // UM1. 
        public static void DisplayArea(Shape s)
        {
            // Variables
            string IND = "  >";
            string num = s.GetNum(); // Indent
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), s.GetColor(), true); // Color
            string type = s.GetType().Name;
            string commonUnit = "ft" + "\u00B2"; // Unicode for superscripted 2 (squared).
            

            // Output
            Console.Write($"{IND} ({num}) ");
            Console.ForegroundColor = color;
            Console.Write($"{type}");
            Console.ResetColor();
            Console.Write($": ");
            Console.WriteLine($"{s.GetArea():F2} {commonUnit}");
        }

        // UM2.
        public static void ShortPause(int duration)
        {
            Thread.Sleep(duration);
        }
    }
}


// INSTRUCTIONS:
    // Practice the principle of polymorphism by writing a program that computes the areas of different shapes cut out of pieces of paper.

    // For all shapes, you need to keep track of the color of the paper and then have a method to compute the area. The area should not be stored as a member variable, but instead, you should store the length of the shapes sides and then compute the area as needed.

    // Your program should include squares (which store a color and a single side), rectangles (which store a color and two sides), and a circle (which store a color and a radius). You should create several kinds of shapes and put them into a single list. Then, iterate through the list and display their areas.