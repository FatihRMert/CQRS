using System.Text.Json.Serialization;

namespace app_consumer.Dtos;

public class CourseDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("teacherName")]
    public string TeacherName { get; set; } = null!;

    [JsonPropertyName("teacherId")]
    public Guid TeacherId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;
}
