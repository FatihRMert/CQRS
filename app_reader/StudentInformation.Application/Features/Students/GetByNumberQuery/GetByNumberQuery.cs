using MediatR;
using StudentInformation.Application.Entities;
using StudentInformation.Application.Repositories;

namespace StudentInformation.Application.Features.Students.GetByNumberQuery;

public sealed record GetByNumberQuery(string Number): IRequest<Student>;

public class GetByNumberQueryHandler : IRequestHandler<GetByNumberQuery, Student>
{
    private readonly StudentRepository studentRepository;

    public GetByNumberQueryHandler(StudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }

    public Task<Student> Handle(GetByNumberQuery request, CancellationToken cancellationToken)
    {
        var number = request.Number;
        
        return studentRepository.GetByNumberAsync(number);
    }
}
