using EduO.Core.Dtos;
using EduO.Core.Models;

namespace EduO.Web.HttpServices.Contract
{
    public interface IBaseService<T> where T : class
    {
        //List<T> GetAll();
        Task<List<T>> GetAllAsync();
        //T GetById(params object?[]? id);
        Task<T> GetByIdAsync(object id);
        //void Create(T grade);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task Delete(object id);
    }
}
