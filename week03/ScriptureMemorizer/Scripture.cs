using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<int> visibleIndices = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        for (int i = 0; i < numberToHide && visibleIndices.Count > 0; i++)
        {
            int randomIndex = random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[randomIndex];

            _words[wordIndex].Hide();
            visibleIndices.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n\n";

        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return result + string.Join(" ", displayWords);
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public double GetHiddenPercentage()
    {
        int hidden = 0;
        foreach (var w in _words)
        {
            if (w.IsHidden()) hidden++;
        }

        return (double)hidden / _words.Count * 100;
    }
}
