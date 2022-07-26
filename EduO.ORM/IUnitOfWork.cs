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
        IBaseRepository<ExClass> ExClass { get; }

        IBaseRepository<Grade> Grades { get; }
        IBaseRepository<CourseType> CourseTypes { get; }
        IBaseRepository<Course> Courses { get; }
        IBaseRepository<Fee> Fees { get; }
        IBaseRepository<Teacher> Teachers { get; }
        IBaseRepository<Student> Students { get; }
        IBaseRepository<User> Users { get; }

        //Special Repositories
        /// /////////////////////////////////////////////////////////////////////////////////
        //IGradesRepository Books { get; }

        int Save();
    }
}