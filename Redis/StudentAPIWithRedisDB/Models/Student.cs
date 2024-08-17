namespace StudentAPIWithRedisDB.Models
{
    public class Student
    {
        public string Id { get; set; } = $"student:{Guid.NewGuid().ToString()}";
        public required string StudentName { get; set; } = string.Empty;

    }
}