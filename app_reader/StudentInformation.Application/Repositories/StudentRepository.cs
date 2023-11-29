using MongoDB.Driver;
using StudentInformation.Application.Entities;

namespace StudentInformation.Application.Repositories;

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

    public Task<Student> GetByNumberAsync(string number)
    {
        return studentCollection.Find(x => x.Number == number).FirstOrDefaultAsync();
    }

    public Task<List<Student>> GetAllAsync()
    {
        return studentCollection.Find(_ => true)
            .SortByDescending(x => x.Number)
            .ToListAsync();
    }
}
