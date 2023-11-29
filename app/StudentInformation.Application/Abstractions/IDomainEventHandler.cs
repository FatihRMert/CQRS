namespace StudentInformation.Application.Abstractions;

public interface IDomainEventHandler
{
    Task HandleAsync(object domainEvent, string channel, CancellationToken cancellationToken = default);
}
