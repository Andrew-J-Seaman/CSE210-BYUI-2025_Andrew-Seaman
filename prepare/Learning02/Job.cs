public class Job
{
    // Attributes
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Methods (Member functions)
    public void Display()
    // Job Title (Company) StartYear-EndYear
    // For example: "Software Engineer (Microsoft) 2019-2022"
    {
        string indent = "   ";
        Console.WriteLine($"{indent}>{_jobTitle} ({_company}) {_startYear}—{_endYear}");
    }
}
