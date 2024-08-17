using StudentAPIWithRedisDB.Models;

namespace StudentAPIWithRedisDB.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student? GetStudentById(string id);
        void AddStudent(Student student);
        Student? UpdateStudent(Student student);
        Student? DeleteStudent(string id);
    }
}
