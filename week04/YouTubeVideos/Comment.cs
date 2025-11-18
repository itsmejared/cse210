public class Comment
{
    private string _authorName;
    private string _text;

    public Comment(string authorName, string text)
    {
        _authorName = authorName;
        _text = text;
    }

    public string GetAuthorName()
    {
        return _authorName;
    }

    public string GetText()
    {
        return _text;
    }
}
