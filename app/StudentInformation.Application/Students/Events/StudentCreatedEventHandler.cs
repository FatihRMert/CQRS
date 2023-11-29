using MediatR;
using StudentInformation.Application.Abstractions;
using StudentInformation.Domain.Students;

namespace StudentInformation.Application.Students.Events;

public class StudentCreatedEventHandler : INotificationHandler<StudentCreatedEvent>
{
    private readonly IDomainEventHandler domainEventHandler;

    public StudentCreatedEventHandler(IDomainEventHandler domainEventHandler)
    {
        this.domainEventHandler = domainEventHandler;
    }

    public Task Handle(StudentCreatedEvent notification, CancellationToken cancellationToken)
    {
        return domainEventHandler.HandleAsync(notification, "student_created_topic", cancellationToken);
    }
}
