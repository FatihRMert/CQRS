using System.Text.Json;
using Confluent.Kafka;
using StudentInformation.Application.Abstractions;

namespace StudentInformation.Infrastructure.EventHandlers;

public class DomainEventHandler : IDomainEventHandler
{
    public DomainEventHandler()
    {
 
    }
    public async Task HandleAsync(object domainEvent, string channel, CancellationToken cancellationToken = default)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "cqrs_kafka:9092",
            AllowAutoCreateTopics = true
        };

        using var producer = new ProducerBuilder<string, string>(config)
        .SetKeySerializer(Serializers.Utf8)
        .SetValueSerializer(Serializers.Utf8)
        .Build();
        var message = new Message<string, string>()
        {
            Value = JsonSerializer.Serialize(domainEvent),
            Key = Guid.NewGuid().ToString()
        };

        try
        {
            Console.WriteLine(message.Value);
            var result = await producer.ProduceAsync(channel, message, cancellationToken);
            Console.WriteLine($"Delivered to '{result.TopicPartitionOffset}'");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
