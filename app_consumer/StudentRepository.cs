using MongoDB.Driver;

namespace app_consumer;

public class StudentRepository
{
    private readonly IMongoCollection<Student> studentCollection;

    public StudentRepository()
    {
        var client = new MongoClient(
            "mongodb://root:password@cqrs_reader_db:27017"
        );

        var database = client.GetDatabase("StudentInformation");

        studentCollection = database.GetCollection<Student>("students");
    }

    public async Task InsertAsync(Student student)
    {
        Console.WriteLine(studentCollection.CollectionNamespace);
        await studentCollection.InsertOneAsync(student);

    }
}
