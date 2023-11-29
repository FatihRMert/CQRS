using app_consumer;

Console.WriteLine("Started StudentInformation Consumer App");


var studentConsumer = new StudentConsumer();

var consumerExecuter = new ConsumerExecuter();

await consumerExecuter.ExecuteAsync(studentConsumer);