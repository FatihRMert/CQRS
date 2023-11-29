namespace StudentInformation.Domain.Abstractions.ValueObjects;

public sealed record FirstName
{
    public string Value { get; private set; }

    public FirstName(string value)
    {
        if(string.IsNullOrEmpty(value))
        {
            throw new ApplicationException("First name is required");
        }
        
        if(value.Length > 120)
        {
            throw new ApplicationException("First name could not be greater than 120");
        }

        if(value.Length < 3)
        {
            throw new ApplicationException("First name could not be less than 3");
        }

        Value = value;
    }
}
