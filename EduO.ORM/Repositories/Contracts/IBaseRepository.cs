using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduO.ORM.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        //////////////////////

        T GetById(params object?[]? id);
        Task<T> GetByIdAsync(params object?[]? id);
        //////////////////////

        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        //////////////////////

        T Update(T entity);
        //////////////////////

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        //////////////////////


        //T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        //Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, 
        //    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);
        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
        //    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        //void Attach(T entity);
        //void AttachRange(IEnumerable<T> entities);
        //int Count();
        //int Count(Expression<Func<T, bool>> criteria);
        //Task<int> CountAsync();
        //Task<int> CountAsync(Expression<Func<T, bool>> criteria);
    }
}