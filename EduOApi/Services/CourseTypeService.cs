using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class CourseTypeService : IBaseService<CourseType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<CourseType> IBaseService<CourseType>.GetAll()
        {
            return _unitOfWork.CourseTypes.GetAll();
        }

        public async Task<IEnumerable<CourseType>> GetAllAsync()
        {
            return await _unitOfWork.CourseTypes.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public CourseType GetById(params object?[]? id)
        {
           return _unitOfWork.CourseTypes.GetById(id);
        }

        public async Task<CourseType> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.CourseTypes.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        CourseType IBaseService<CourseType>.Add(CourseType entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CourseTypes.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<CourseType> AddAsync(CourseType entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.CourseTypes.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        ///////////////////////////////////////////////////////////////
        
        public CourseType Update(CourseType entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CourseTypes.Update(entity);
            _unitOfWork.Save();
            return entity;
        }

        ///////////////////////////////////////////////////////////////
        ///
        public CourseType Delete(CourseType entity)
        {
            _unitOfWork.CourseTypes.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
