using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class TeacherService : IBaseService<Teacher>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<Teacher> IBaseService<Teacher>.GetAll()
        {
            return _unitOfWork.Teachers.GetAll();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public Teacher GetById(params object?[]? id)
        {
           return _unitOfWork.Teachers.GetById(id);
        }

        public async Task<Teacher> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        Teacher IBaseService<Teacher>.Add(Teacher entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Teachers.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<Teacher> AddAsync(Teacher entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Teachers.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        /////////////////////////////////////////////////////////////
        ///
        public Teacher Update(Teacher entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Teachers.Update(entity);
            _unitOfWork.Save();

            return entity;
        }

        /////////////////////////////////////////////////////////////
        ///
        public Teacher Delete(Teacher entity)
        {
            _unitOfWork.Teachers.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
