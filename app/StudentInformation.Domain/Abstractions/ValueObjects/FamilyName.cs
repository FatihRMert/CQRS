namespace StudentInformation.Domain.Abstractions.ValueObjects;

public sealed record FamilyName
{
    public string Value { get; private set; }

    public FamilyName(string value)
    {
        if(string.IsNullOrEmpty(value))
        {
            throw new ApplicationException("Family name is required");
        }
        
        if(value.Length > 60)
        {
            throw new ApplicationException("Family name could not be greater than 60");
        }

        if(value.Length < 3)
        {
            throw new ApplicationException("Family name could not be less than 3");
        }

        Value = value;
    }
}
