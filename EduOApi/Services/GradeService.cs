using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Grade>> GetAll()
        {
            return await _unitOfWork.Grades.GetAllAsync();
        }

        public async Task<Grade> GetById(int id)
        {
            return await _unitOfWork.Grades.GetByIdAsync(id);
        }

        public async Task<Grade> Add(Grade grade)
        {
            await _unitOfWork.Grades.AddAsync(grade);
            _unitOfWork.Save();

            return grade;
        }

        public Grade Update(Grade grade)
        {
            _unitOfWork.Grades.Update(grade);
            _unitOfWork.Save();

            return grade;
        }

        public Grade Delete(Grade grade)
        {
            _unitOfWork.Grades.Delete(grade);
            _unitOfWork.Save();

            return grade;
        }

        //public Task<bool> IsvalidGenre(int id)
        //{
        //    return _context.Grades.AnyAsync(g => g.Id == id);
        //}
    }
}
