using AutoMapper;
using EduO.Core.Dtos;
using EduO.Core.Models;
using EduO.Api.Services;
using EduO.Api.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly IGradeService _gradeService;

        //private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        //private long _maxAllowedPosterSize = 1048576;

        public StudentsController(IStudentService studentService, IGradeService gradeService, IMapper mapper)
        {
            _studentService = studentService;
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _studentService.GetAll();

            var data = _mapper.Map<IEnumerable<StudentDetailsDto>>(students);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var student = await _studentService.GetById(id);

            if(student == null)
                return NotFound();

            var dto = _mapper.Map<StudentDetailsDto>(student);

            return Ok(dto);
        }

        [HttpGet("GetByGradeId")]
        public async Task<IActionResult> GetByGradeIdAsync(byte gradeId)
        {
            var students = await _studentService.GetAll(gradeId);
            var data = _mapper.Map<IEnumerable<StudentDetailsDto>>(students);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentDto dto)
        {
            //if (dto.Poster == null)
            //    return BadRequest("Poster is required!");

            //if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            //    return BadRequest("Only .png and .jpg images are allowed!");

            //if(dto.Poster.Length > _maxAllowedPosterSize)
            //    return BadRequest("Max allowed size for poster is 1MB!");

            //var isValidGenre = await _gradeService.IsvalidGenre(dto.GradeId);

            //if(!isValidGenre)
            //    return BadRequest("Invalid genere ID!");

            //using var dataStream = new MemoryStream();

            //await dto.Poster.CopyToAsync(dataStream);

            var student = _mapper.Map<Student>(dto);
            //movie.Poster = dataStream.ToArray();

            _studentService.Add(student);

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, StudentDto dto)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
                return NotFound($"No Student was found with ID {id}");

            //var isValidGenre = await _gradeService.IsvalidGenre(dto.GradeId);

            //if (!isValidGenre)
            //    return BadRequest("Invalid grade ID!");

            //if(dto.Poster != null)
            //{
            //    if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            //        return BadRequest("Only .png and .jpg images are allowed!");

            //    if (dto.Poster.Length > _maxAllowedPosterSize)
            //        return BadRequest("Max allowed size for poster is 1MB!");

            //    using var dataStream = new MemoryStream();

            //    await dto.Poster.CopyToAsync(dataStream);

            //    movie.Poster = dataStream.ToArray();
            //}

            student.Name = dto.Name;
            student.GradeId = dto.GradeId;
            //movie.Year = dto.Year;
            //movie.Storeline = dto.Storeline;
            //movie.Rate = dto.Rate;

            _studentService.Update(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
                return NotFound($"No student was found with ID {id}");

            _studentService.Delete(student);

            return Ok(student);
        }
    }
}