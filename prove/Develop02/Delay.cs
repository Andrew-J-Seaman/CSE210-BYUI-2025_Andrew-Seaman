public class Delay
{
    private int _long;
    private int _short;

    // Constructor for delay variable values
    public Delay()
    {
        // Seconds to milliseconds
        _long  = 2 * 1000;
        _short = (int)(1.5 * 1000); 
    }

//==================================
    // Private methods: 
    //      1) Wait
    //      2) Clear
    //      3) Write
    //      4) Blank Line
//==================================
    
 // 1) Wait
    private void Wait(int length)
    { 
        // Wait delay in milliseconds
        Thread.Sleep(length);
    }
// 2) Clear
    private void Clear()
    {
        Console.Clear();
    }
// 3) Write
    private void Write(string text){
        Console.Write($"{text}");
    }
// 4) Blank line
    private void NewLine(){
        Console.WriteLine("\n");
    }


//==================================
    // Public methods: 
    //      1) Display 1
    //      2) Display 2
    //      3) Display 3
    //      4) Display Error
//==================================
 
// 1) Display 1
    public void Display1(string message1){
        Clear();
        Write(message1);
        Wait(_short);
        NewLine();
    }
// 2) Display 2
    public void Display2(string message1, string message2){
        Clear();
        Write($"{message1}");
        Wait(_long);
        Write($"{message2}");
        Wait(_short);
        Clear();
    }
// 3) Display 3
    public void Display3(string message1, string message2, string message3){
        Clear();
        Write($"{message1}");
        Wait(_long);
        Write($"{message2}");
        Wait(_short);
        Clear();
        Write($"{message3}");
        Wait(_short);
        NewLine();
    }
// 4) Display Error
    public void DisplayErr2(string message1, string message2){
        Clear();
        Write($"{message1}");
        Wait(_long);
        Display1(message2);
    }
}

