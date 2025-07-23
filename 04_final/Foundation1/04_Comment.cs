public class Comment
{
    // ATTRIBUTES
    private string _commenter;
    private string _text;


    // CONSTRUCTORS
    public Comment(string commenter, string text)
    {
        _commenter = commenter;
        _text = text;
    }


    // METHODS
    public string GetCommentString()
    {
        return $"{_commenter}: {_text}";
    }


}
