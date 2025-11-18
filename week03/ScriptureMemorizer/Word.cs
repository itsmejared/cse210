using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Keep punctuation at the end (.,!?)
        char lastChar = _text[_text.Length - 1];
        bool hasPunctuation = char.IsPunctuation(lastChar);

        string core = hasPunctuation ? _text[..^1] : _text;
        string underscores = new string('_', core.Length);

        return hasPunctuation ? underscores + lastChar : underscores;
    }
}
