using StackExchange.Redis;
using StudentAPIWithRedisDB.Models;
using System.Text.Json;

namespace StudentAPIWithRedisDB.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public StudentRepository(IConnectionMultiplexer redis)
        {
            this._redis = redis;
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentOutOfRangeException(nameof(student));
            }
            var db = _redis.GetDatabase();
            var serializedStudent = JsonSerializer.Serialize(student);
            db.StringSet(student.Id, serializedStudent);
        }

        public Student? DeleteStudent(string id)
        {
            var db = _redis.GetDatabase();
            var student = db.StringGet(id);
            if (student.IsNullOrEmpty)
            {
                return null;
            }
            db.KeyDelete(id);
            return JsonSerializer.Deserialize<Student>(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var db = _redis.GetDatabase();

            var studentKeys = db.Multiplexer.GetServer(_redis.GetEndPoints().First()).Keys(pattern: "student:*");

            var students = new List<Student>();

            foreach (var key in studentKeys)
            {
                var studentJson = db.StringGet(key);
                if (!studentJson.IsNullOrEmpty)
                {
                    var student = JsonSerializer.Deserialize<Student>(studentJson);
                    students.Add(student);
                }
            }

            return students;
        }

        public Student? GetStudentById(string id)
        {
            var db = _redis.GetDatabase();
            var student = db.StringGet(id);
            if (student.IsNullOrEmpty)
            {
                return null;
            }
            return JsonSerializer.Deserialize<Student>(student);
        }

        public Student? UpdateStudent(Student student)
        {
            var db = _redis.GetDatabase();

            var id = student.Id;
            if (db.KeyExists(id))
            {
                var updatedStudentJson = JsonSerializer.Serialize(student);
                db.StringSet(id, updatedStudentJson);
                return student;
            }
            else
            {
                return null;
            }
        }
    }
}
