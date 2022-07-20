using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class ExClassService : IBaseService<ExClass>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<ExClass> IBaseService<ExClass>.GetAll()
        {
            return _unitOfWork.ExClass.GetAll();
        }

        public async Task<IEnumerable<ExClass>> GetAllAsync()
        {
            return await _unitOfWork.ExClass.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public ExClass GetById(params object?[]? id)
        {
           return _unitOfWork.ExClass.GetById(id);
        }

        public async Task<ExClass> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.ExClass.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        ExClass IBaseService<ExClass>.Add(ExClass entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ExClass.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<ExClass> AddAsync(ExClass entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.ExClass.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        /////////////////////////////////////////////////////////////
        ///
        public ExClass Update(ExClass entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ExClass.Update(entity);
            _unitOfWork.Save();

            return entity;
        }

        /////////////////////////////////////////////////////////////
        ///
        public ExClass Delete(ExClass entity)
        {
            _unitOfWork.ExClass.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
