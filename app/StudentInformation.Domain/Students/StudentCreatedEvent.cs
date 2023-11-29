using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Abstractions.ValueObjects;

namespace StudentInformation.Domain.Students;

public sealed record StudentCreatedEvent(StudentId Id, StudentNumber Number, FirstName FirstName, FamilyName FamilyName): IDomainEvent;