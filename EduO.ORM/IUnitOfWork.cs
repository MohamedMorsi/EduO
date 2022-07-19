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
        IBaseRepository<Student> Students { get; }
        IBaseRepository<Grade> Grades { get; }

        //Special Repositories
        /// /////////////////////////////////////////////////////////////////////////////////
        //IGradesRepository Books { get; }

        int Save();
    }
}