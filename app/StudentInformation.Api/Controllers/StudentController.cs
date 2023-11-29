using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentInformation.Application.Teachers.RecordNewStudent;
using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Students;

namespace StudentInformation.Api.Controllers;

[Route("students")]
[ApiController]
public class StudentController: ControllerBase
{
    private readonly IMediator mediator;

    public StudentController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<StudentId>> CreateAsync([FromBody] CreateStudentRequestBody requestBody)
    {
        var command = new RecordNewStudentCommand(
            new StudentNumber(requestBody.Number),
            new FirstName(requestBody.FirstName),
            new FamilyName(requestBody.FamilyName)
        );

        var response = await mediator.Send(command);

        return Ok(response);
    }
}

public sealed record CreateStudentRequestBody
{
    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }
    
    [JsonPropertyName("familyName")]
    public required string FamilyName { get; set; }
    
    [JsonPropertyName("number")]
    public required string Number { get; set; }
    
}
