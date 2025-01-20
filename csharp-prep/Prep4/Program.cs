using System; // OR: `using System.Collections.Generic;` which specifies the use of generics if your settings don't already include so you don't have to explicitly declare them.

class Program
{
    static void Main(string[] args)
    {
        // Clear the console
         Console.Clear();

        // Default greeting
        Console.WriteLine("> Hello Prep4 World! \n");

        // Explanation
        Console.WriteLine("> You'll be asked to build a list of numbers one at a time. Type \"0\" to end. \n");

        // Advance?
        Console.Write("   > PRESS [ENTER] ");
        Console.ReadLine();
        Console.Clear();

        // New list
        List<int> series = new List<int>();

        bool notZero = true;
        while (notZero)
        {
            // User input: number series
            Console.Write("> Enter a new number (+/-): ");
            string inputString = Console.ReadLine();
            int inputInt = int.Parse(inputString);
            
            if (inputInt == 0)
            {
                Console.Clear();
                Console.WriteLine("> Thank you! Based on your entries:");
                notZero = false;
            }
            else
            {
                series.Add(inputInt);
            }
        }

        // Find summary stats
        List<int> positive = new List<int>();

        foreach (int num in series)
        {
            if (num > 0)
            {
                positive.Add(num);
            }
        }
        int min = positive.Min();
        int sum = series.Sum();
        double avg = series.Average();
        int max = series.Max();
        
        // Print summary stats
        Console.WriteLine($"   > Sum: {sum}");
        Console.WriteLine($"   > Average: {avg}");
        Console.WriteLine($"   > Maximum: {max}");
        Console.WriteLine($"   > Smallest Positive: {min}");

        // Sort the list in ascending order
        series.Sort();

        // Format the sorted list as a string
        string sortedList = "";
        foreach (int num in series)
        {
            sortedList = sortedList + " " + num + ",";
        }
        // Remove the trailing comma
        if (sortedList.Length > 0)
        {
            sortedList = sortedList.TrimEnd(',');
        }
        // Print the sorted list
        Console.WriteLine($"   > Sorted List: {sortedList}");
    }
}

// NOTES:

/* DATA STRUCTURES:
    1. Lists
    2. Sets
    3. Dictionaries
    4. etc...
*/

/* LISTS:

// Additional info on lists: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-5.0

// Format: List<dataType> variableName = new List<dataType>();
// Get size of list: Console.WriteLine(variableName.Count);  // .Count is a property not a function
// Iterating through a list: foreach loop

***Examples: 

1. Integers
    List<int> numbers = new List<int>(); 

    numbers.Add("phone");
    numbers.Add("keyboard");
    numbers.Add("mouse");

    Console.WriteLine(numbers.Count)

2. Strings
// Declare data type of list items. New list instance:
    List<string> words = new List<string>();  

// Add items to list:
    words.Add("phone");
    words.Add("keyboard");
    words.Add("mouse");

// Get list size:
    Console.WriteLine(words.Count)

// Iterate thorugh list:
    foreach (string word in words) // Using `foreach`.
    {
        Console.WriteLine(word);
    }

    OR,

    for (int i = 0; i < words.Count; i++) // Using `for` and item index
    {
        Console.WriteLine(words[i]);
    }

3. Template (data type specified later) 
// Special case. Data type specified later.
    List<T> template = new List<T>();

    template.Add("phone");
    template.Add("keyboard");
    template.Add("mouse");

    Console.WriteLine(template.Count)
*/