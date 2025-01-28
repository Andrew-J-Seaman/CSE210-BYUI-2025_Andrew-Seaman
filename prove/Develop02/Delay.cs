// AUTHOR: Andrew Seaman
// TITLE: Delay Class
// DISCLOSURE: Development was aided by Chat GPT 4.0

public class Delay
{
/* >>> PRIVATE ATTRIBUTES (2) <<< ==========
//
//      1) _long
//      2) _short
//
==========================================*/
    // 1)
    private int _long;
    // 2)
    private int _short;

/* >>> CONSTRUCTOR (2) <<< =================
//
//      1) Delay: 
//          -   _long
//          -   _short
//
==========================================*/
    // 1)
    public Delay()
    {
        // Seconds to milliseconds
        _long  = 1 * 1000;
        _short = (int)(.5 * _long); 
    }

/* >>> PRIVATE METHODS <<< =================
//  Toal: 4

//      1) Wait
//      2) Clear
//      3) Write
//      4) Blank Line
//========================================*/
    
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

/* >>> PUBLIC METHODS (4) <<< ==============
//
//      1) Display1
//      2) Display2
//      3) Display3
//      4) DisplayError
//
//========================================*/
 
// 1)
    public void Display1(string message1){
        Clear();
        Write(message1);
        Wait(_short);
        NewLine();
    }
// 2)
    public void Display2(string message1, string message2){
        Clear();
        Write($"{message1}");
        Wait(_long);
        Write($"{message2}");
        Wait(_short);
        Clear();
    }
// 3)
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
// 4)
    public void DisplayErr2(string message1, string message2){
        Clear();
        Write($"{message1}");
        Wait(_long);
        Display1(message2);
    }
}

