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

        public IBaseRepository<ExClass> ExClass { get; private set; }
        public IBaseRepository<Grade> Grades { get; private set; }
        public IBaseRepository<CourseType> CourseTypes { get; private set; }
        public IBaseRepository<Course> Courses  { get; private set; }
        public IBaseRepository<Fee> Fees { get; private set; }
        public IBaseRepository<Teacher> Teachers { get; private set; }
        public IBaseRepository<Student> Students { get; private set; }
        public IBaseRepository<User> Users { get; private set; }

        //public IGradesRepository Grades { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            ExClass = new BaseRepository<ExClass>(_context);

            Grades = new BaseRepository<Grade>(_context);
            CourseTypes = new BaseRepository<CourseType>(_context);
            Courses = new BaseRepository<Course>(_context);
            Fees = new BaseRepository<Fee>(_context);
            Teachers = new BaseRepository<Teacher>(_context);
            Students = new BaseRepository<Student>(_context);
            Users = new BaseRepository<User>(_context);
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