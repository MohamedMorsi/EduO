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
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Teacher> _TeacherService;

        public TeachersController(IBaseService<Teacher> TeacherService, IMapper mapper)
        {
            _mapper = mapper;
            _TeacherService = TeacherService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Teachers = _TeacherService.GetAll();
            var dtos = _mapper.Map<IEnumerable<TeacherDto>>(Teachers);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Teachers = await _TeacherService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TeacherDto>>(Teachers);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var Teacher = _TeacherService.GetById(id);
            var dto = _mapper.Map<TeacherDto>(Teacher);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Teacher = await _TeacherService.GetByIdAsync(id);
            var dto = _mapper.Map<TeacherDto>(Teacher);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(TeacherDto dto)
        {
            var Teacher = _mapper.Map<Teacher>(dto);

            _TeacherService.Add(Teacher);

            return Ok(Teacher);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(TeacherDto dto)
        {
            var Teacher = _mapper.Map<Teacher>(dto);

            await _TeacherService.AddAsync(Teacher);

            return Ok(Teacher);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherDto dto)
        {
            var Teacher = await _TeacherService.GetByIdAsync(id);

            if (Teacher == null)
                return NotFound($"No Teacher was found with ID: {id}");

            Teacher.Name = dto.Name;

            _TeacherService.Update(Teacher);

            return Ok(Teacher);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Teacher = await _TeacherService.GetByIdAsync(id);

            if (Teacher == null)
                return NotFound($"No Teacher was found with ID: {id}");

            _TeacherService.Delete(Teacher);

            return Ok(Teacher);
        }

    }
}