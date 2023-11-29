using System.Text.Json;
using app_consumer.Dtos;
using Confluent.Kafka;

namespace app_consumer;

public class StudentConsumer : IConsumer
{
    public async Task ExecuteAsync()
    {
        var config = new ConsumerConfig()
        {
            BootstrapServers = "cqrs_kafka:9092",
            GroupId = "student_created_group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            AllowAutoCreateTopics = true
        };

        using var consumer = new ConsumerBuilder<string, string>(config)
        .Build();

        consumer.Subscribe("student_created_topic");
        var repository = new StudentRepository();
        while(true)
        {
            try
            {
                Console.WriteLine("I'm waiting for new students");
                var consumeResult = consumer.Consume();
                Console.WriteLine("Consume Result" + consumeResult.Topic);
                var messageValue = consumeResult.Message.Value;
                Console.WriteLine("Consume Result Message" + messageValue);
                if(string.IsNullOrEmpty(messageValue) == false)
                {
                    try
                    {
                        var studentDto = JsonSerializer.Deserialize<StudentDto>(messageValue);
                        Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {messageValue}");
                        var student = new Student
                        {
                            FamilyName = studentDto!.FamilyName.Value,
                            FirstName = studentDto.FirstName.Value,
                            Id = studentDto.Id.Value.ToString(),
                            Number = studentDto.Number.Value
                        };
                        await repository.InsertAsync(student);
                        consumer.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Consumer App Threw an Exception, {e.Message}");
                        throw;
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine($"Consumer App Threw an Exception, {e.Message}");
                throw;
            }
        }
    }
}
