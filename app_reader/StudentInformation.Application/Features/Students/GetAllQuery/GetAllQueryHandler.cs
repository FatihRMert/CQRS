using MediatR;
using StudentInformation.Application.Entities;
using StudentInformation.Application.Repositories;

namespace StudentInformation.Application.Features.Students.GetAllQuery;

public sealed record GetAllQuery: IRequest<List<Student>>;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<Student>>
{
    private readonly StudentRepository studentRepository;

    public GetAllQueryHandler(StudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }

    Task<List<Student>> IRequestHandler<GetAllQuery, List<Student>>.Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return studentRepository.GetAllAsync();
    }
}
