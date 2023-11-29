namespace StudentInformation.Domain.Students;

public sealed record StudentNumber
{
    public string Value { get; private set; }
    public StudentNumber(string value)
    {
        if(string.IsNullOrEmpty(value)) 
        {
            throw new ApplicationException("Student number is required");
        }
        
        if(value.Length != 12) 
        {
            throw new ApplicationException("Invalid student number, its length should be 12");
        }
        
        Value = value;
    }
}
