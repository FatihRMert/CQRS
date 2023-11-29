namespace app_consumer;

public interface IConsumer
{
    Task ExecuteAsync();
}

public interface IConsumerExecuter
{
    Task ExecuteAsync(params IConsumer[] consumers);
}

public class ConsumerExecuter: IConsumerExecuter
{
    public async Task ExecuteAsync(params IConsumer[] consumers)
    {
        foreach (var consumer in consumers)
        {
            await Task.Run(() => consumer.ExecuteAsync());
        }
    }
}
