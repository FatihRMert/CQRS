using System.Text.Json.Serialization;

namespace app_consumer.Dtos;

public class StudentDto
{
    [JsonPropertyName("Id")]
    public StudentId Id { get; set; } = null!;

    [JsonPropertyName("FirstName")]
    public FirstName FirstName { get; set; } = null!;
    
    [JsonPropertyName("FamilyName")]
    public FamilyName FamilyName { get; set; } = null!;
    [JsonPropertyName("Number")]
    public StudentNumber Number { get; set; } = null!;
}

public sealed record FirstName(string Value);
public sealed record FamilyName(string Value);
public sealed record StudentNumber(string Value);
public sealed record StudentId(Guid Value);
