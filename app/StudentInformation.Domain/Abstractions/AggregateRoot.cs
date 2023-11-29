using System.Diagnostics;

namespace StudentInformation.Domain.Abstractions;

public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _events = new();

    public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();


    protected void RaiseEvent(IDomainEvent domainEvent)
    {
        Debug.Assert(domainEvent != null, "Raises domain event is null");

        _events.Add(domainEvent);
    }

    public bool HasRaisedEvent() => _events.Count > 0;
}
