using EduO.Core.Models;
using EduO.ORM.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.ORM
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Grade> Grades { get; }
        IBaseRepository<Student> Students { get; }
        IBaseRepository<Course> Coursees { get; }
        IBaseRepository<Fee> Fees { get; }
        IBaseRepository<Teacher> Teachers { get; }
        IBaseRepository<User> Users { get; }

        //Special Repositories
        /// /////////////////////////////////////////////////////////////////////////////////
        //IGradesRepository Books { get; }

        int Save();
    }
}