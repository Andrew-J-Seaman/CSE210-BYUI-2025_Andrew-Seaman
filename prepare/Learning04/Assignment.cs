using System;

public class Assignment
{
// ATTRIBUTES
    protected string _studentName;
    protected string _topic;

// CONSTRUCTORS
    public Assignment(string studentName, string topic){
        _studentName = studentName;
        _topic = topic;
    }

// METHODS
    public string GetSummary(){
        return $"{_studentName} - {_topic}";
    }
}