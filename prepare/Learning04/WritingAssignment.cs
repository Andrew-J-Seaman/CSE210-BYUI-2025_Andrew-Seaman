using System;

public class WritingAssignment : Assignment
{
    // ATTRIBUTES
    private string _title;

    // CONSTRUCTORS
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // METHODS
    public string GetWritingInformation()
    {
        return $"{_studentName} - {_topic}\n{_title}";
    }
}
