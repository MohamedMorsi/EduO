using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Student>> GetAll(int gradeId = 0)
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

        public async Task<Student> Add(Student student)
        {
            await _unitOfWork.Students.AddAsync(student);
            _unitOfWork.Save();

            return student;
        }

        public Student Delete(Student student)
        {
            _unitOfWork.Students.Delete(student);
            _unitOfWork.Save();

            return student;
        }
        public Student Update(Student student)
        {
            _unitOfWork.Students.Update(student);
            _unitOfWork.Save();

            return student;
        }
    }
}