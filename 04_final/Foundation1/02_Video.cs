public class Video
{
    // ATTRIBUTES
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;


    // CONSTRUCTORS
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }


    // METHODS
    public void DisplayVideo()
    {
        Console.WriteLine($"  Title: {_title}");
        Console.WriteLine($"  Author: {_author}");
        Console.WriteLine($"  Length: {_length} seconds");
        Console.WriteLine($"  Comments: ");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"     > {comment.GetCommentString()}");
        }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void AddCommentUsingStrings(string commenter, string text)
    {
        Comment comment = new Comment(commenter, text);
        _comments.Add(comment);
    }

}