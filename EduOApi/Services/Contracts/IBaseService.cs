using EduO.Core.Models;

namespace EduO.Api.Services.Contracts
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        //////////////////////////////////
        
        T GetById(params object?[]? id);
        Task<T> GetByIdAsync(params object?[]? id);
        //////////////////////////////////

        T Add(T entity);
        Task<T> AddAsync(T entity);
        //////////////////////////////////

        T Update(T entity);
        //////////////////////////////////

        T Delete(T entity);
        //////////////////////////////////

    }
}