﻿using EduO.Core.Models;
using EduO.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Services
{
    public class StudentService : IBaseService<Student>
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /////////////////////////////////////////////////////////////
        
        IEnumerable<Student> IBaseService<Student>.GetAll()
        {
            return _unitOfWork.Students.GetAll();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }
        /////////////////////////////////////////////////////////////

        public Student GetById(params object?[]? id)
        {
           return _unitOfWork.Students.GetById(id);
        }

        public async Task<Student> GetByIdAsync(params object?[]? id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }
        /////////////////////////////////////////////////////////////

        Student IBaseService<Student>.Add(Student entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Students.Add(entity);
            _unitOfWork.Save();

            return entity;
        }

        public async Task<Student> AddAsync(Student entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Students.AddAsync(entity);
            _unitOfWork.Save();

            return entity;
        }
        /////////////////////////////////////////////////////////////
        ///
        public Student Update(Student entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Students.Update(entity);
            _unitOfWork.Save();

            return entity;
        }

        /////////////////////////////////////////////////////////////
        ///
        public Student Delete(Student entity)
        {
            _unitOfWork.Students.Delete(entity);
            _unitOfWork.Save();

            return entity;
        }
    }
}
