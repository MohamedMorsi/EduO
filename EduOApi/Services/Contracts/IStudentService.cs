using EduO.Core.Models;

namespace EduO.Api.Services.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll(int gradeId = 0);
        Task<Student> GetById(int id);
        Task<Student> Add(Student student);
        Student Update(Student student);
        Student Delete(Student student);
    }
}