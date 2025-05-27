class WordCounter
{
    private List<string> _words;

    public WordCounter(string text)
    {
        // Constructor logic here
        _words = new List<string>(); // New instance
        SplitTextIntoWords(text); // Fill new instance with words
        DisplayWords(); // Display the words
    }

    private void SplitTextIntoWords(string text)
    {
        // Split the text into words and store them in the _words list
        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            _words.Add(word);
        }
    }

    public void DisplayWords()
    {
        foreach (string word in _words)
        {
            Console.WriteLine(word);
        }
    }
}
