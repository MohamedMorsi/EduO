using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class GradeService : IBaseService<Grade>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<Grade> IBaseService<Grade>.GetAll()
        {
            return _unitOfWork.Grades.GetAll();
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await _unitOfWork.Grades.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public Grade GetById(params object?[]? id)
        {
           return _unitOfWork.Grades.GetById(id);
        }

        public async Task<Grade> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.Grades.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        Grade IBaseService<Grade>.Add(Grade entity)
        {
            _unitOfWork.Grades.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<Grade> AddAsync(Grade entity)
        {
            await _unitOfWork.Grades.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        /////////////////////////////////////////////////////////////
        ///
        public Grade Update(Grade entity)
        {
            _unitOfWork.Grades.Update(entity);
            _unitOfWork.Save();

            return entity;
        }

        /////////////////////////////////////////////////////////////
        ///
        public Grade Delete(Grade entity)
        {
            _unitOfWork.Grades.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
