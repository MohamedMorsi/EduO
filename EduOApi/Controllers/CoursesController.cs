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
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Course> _CourseService;

        public CoursesController(IBaseService<Course> CourseService, IMapper mapper)
        {
            _mapper = mapper;
            _CourseService = CourseService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Courses = _CourseService.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(Courses);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Courses = await _CourseService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(Courses);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var Course = _CourseService.GetById(id);
            var dto = _mapper.Map<CourseDto>(Course);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Course = await _CourseService.GetByIdAsync(id);
            var dto = _mapper.Map<CourseDto>(Course);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(CourseDto dto)
        {
            var Course = _mapper.Map<Course>(dto);

            _CourseService.Add(Course);

            return Ok(Course);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CourseDto dto)
        {
            var Course = _mapper.Map<Course>(dto);

            await _CourseService.AddAsync(Course);

            return Ok(Course);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CourseDto dto)
        {
            var course = await _CourseService.GetByIdAsync(id);

            if (course == null)
                return NotFound($"No Course was found with ID: {id}");

            _mapper.Map(dto, course);

            var updatedDto = _CourseService.Update(course);

            return Ok(course);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Course = await _CourseService.GetByIdAsync(id);

            if (Course == null)
                return NotFound($"No Course was found with ID: {id}");

            _CourseService.Delete(Course);

            return Ok(Course);
        }

    }
}