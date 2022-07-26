using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class CourseService : IBaseService<Course>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<Course> IBaseService<Course>.GetAll()
        {
            return _unitOfWork.Courses.GetAll();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _unitOfWork.Courses.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public Course GetById(params object?[]? id)
        {
           return _unitOfWork.Courses.GetById(id);
        }

        public async Task<Course> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.Courses.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        Course IBaseService<Course>.Add(Course entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Courses.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<Course> AddAsync(Course entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Courses.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        /////////////////////////////////////////////////////////////
        ///
        public Course Update(Course entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Courses.Update(entity);
            _unitOfWork.Save();

            return entity;
        }

        /////////////////////////////////////////////////////////////
        ///
        public Course Delete(Course entity)
        {
            _unitOfWork.Courses.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
