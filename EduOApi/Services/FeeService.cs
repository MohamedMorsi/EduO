using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class FeeService : IBaseService<Fee>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<Fee> IBaseService<Fee>.GetAll()
        {
            return _unitOfWork.Fees.GetAll();
        }

        public async Task<IEnumerable<Fee>> GetAllAsync()
        {
            return await _unitOfWork.Fees.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public Fee GetById(params object?[]? id)
        {
           return _unitOfWork.Fees.GetById(id);
        }

        public async Task<Fee> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.Fees.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        Fee IBaseService<Fee>.Add(Fee entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Fees.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<Fee> AddAsync(Fee entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Fees.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        /////////////////////////////////////////////////////////////
        ///
        public Fee Update(Fee entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Fees.Update(entity);
            _unitOfWork.Save();

            return entity;
        }

        /////////////////////////////////////////////////////////////
        ///
        public Fee Delete(Fee entity)
        {
            _unitOfWork.Fees.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
