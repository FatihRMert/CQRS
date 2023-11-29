using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentInformation.Application.Entities;
using StudentInformation.Application.Features.Students.GetAllQuery;
using StudentInformation.Application.Features.Students.GetByNumberQuery;

namespace StudentInformation.Api.Controllers;

[ApiController]
[Route("students")]
public class StudentController: ControllerBase
{
    private readonly IMediator mediator;

    public StudentController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetListAsync()
    {
        var query = new GetAllQuery();

        var response = await mediator.Send(query);

        return Ok(response);
    }


    [HttpGet("{number}")]
    public async Task<ActionResult<Student>> GetByNumberAsync(string number)
    {
        var query = new GetByNumberQuery(number);

        var response = await mediator.Send(query);

        return Ok(response);
    }
}
