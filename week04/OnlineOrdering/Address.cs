using System.Text;
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA()
    {
        return _country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_street);
        sb.AppendLine(_city);
        sb.AppendLine(_state);
        sb.Append(_country);
        return sb.ToString();
    }
}
