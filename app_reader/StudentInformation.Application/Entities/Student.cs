using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentInformation.Application.Entities;

public class Student
{
    [BsonId]
    public string? Id { get; set; }

    [BsonElement("firstName")]
    public string FirstName { get; set; } = null!;

    [BsonElement("familyName")]
    public string FamilyName { get; set; } = null!;

    [BsonElement("number")]
    public string Number { get; set; } = null!;
}
