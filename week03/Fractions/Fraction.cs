public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor 1: 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: top/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // String representation "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Decimal representation
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
