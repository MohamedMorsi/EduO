using AutoMapper;
using EduO.Core.Dtos;
using EduO.Core.Models;
using EduO.Api.Services;
using EduO.Api.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EduO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrator")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Student> _Studentservice;

        public StudentsController(IBaseService<Student> Studentservice, IMapper mapper)
        {
            _mapper = mapper;
            _Studentservice = Studentservice;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Students = _Studentservice.GetAll();
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(Students);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Students = await _Studentservice.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(Students);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var Student = _Studentservice.GetById(id);
            var dto = _mapper.Map<StudentDto>(Student);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Student = await _Studentservice.GetByIdAsync(id);
            var dto = _mapper.Map<StudentDto>(Student);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(StudentDto dto)
        {
            var Student = _mapper.Map<Student>(dto);

            _Studentservice.Add(Student);

            return Ok(Student);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(StudentDto dto)
        {
            var Student = _mapper.Map<Student>(dto);

            await _Studentservice.AddAsync(Student);

            return Ok(Student);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] StudentDto dto)
        {
            var Student = await _Studentservice.GetByIdAsync(id);

            if (Student == null)
                return NotFound($"No Student was found with ID: {id}");

            Student.Name = dto.Name;

            _Studentservice.Update(Student);

            return Ok(Student);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Student = await _Studentservice.GetByIdAsync(id);

            if (Student == null)
                return NotFound($"No Student was found with ID: {id}");

            _Studentservice.Delete(Student);

            return Ok(Student);
        }

    }
}