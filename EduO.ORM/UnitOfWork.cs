using EduO.Core;
using EduO.Core.Models;
using EduO.ORM.Repositories;
using EduO.ORM.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.ORM
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Grade> Grades { get; private set; }
        public IBaseRepository<Student> Students { get; private set; }
        public IBaseRepository<Course> Coursees => throw new NotImplementedException();
        public IBaseRepository<Fee> Fees => throw new NotImplementedException();
        public IBaseRepository<Teacher> Teachers => throw new NotImplementedException();
        public IBaseRepository<User> Users => throw new NotImplementedException();

        //public IGradesRepository Grades { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Students = new BaseRepository<Student>(_context);
            Grades = new BaseRepository<Grade>(_context);
            //Grades = new GradesRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}