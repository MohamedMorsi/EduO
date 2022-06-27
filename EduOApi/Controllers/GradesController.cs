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
    [Authorize]
    public class GradesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService, IMapper mapper)
        {
            _mapper = mapper;
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var grades = await _gradeService.GetAll();
            var dtos = _mapper.Map<IEnumerable<GradeDto>>(grades);

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var grade = await _gradeService.GetById(id);
            var dto = _mapper.Map<GradeDto>(grade);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(GradeDto dto)
        {
            var grade = _mapper.Map<Grade>(dto);

            await _gradeService.Add(grade);

            return Ok(grade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] GradeDto dto)
        {
            var grade = await _gradeService.GetById(id);

            if (grade == null)
                return NotFound($"No grade was found with ID: {id}");

            grade.Name = dto.Name;

            _gradeService.Update(grade);

            return Ok(grade);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var grade = await _gradeService.GetById(id);

            if (grade == null)
                return NotFound($"No grade was found with ID: {id}");

            _gradeService.Delete(grade);

            return Ok(grade);
        }


        //[HttpGet("GetByName")]
        //public IActionResult GetByName()
        //{
        //    return Ok(_unitOfWork.Books.Find(b => b.Title == "New Book", new[] { "Author" }));
        //}

        //[HttpGet("GetAllWithAuthors")]
        //public IActionResult GetAllWithAuthors()
        //{
        //    return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("New Book"), new[] { "Author" }));
        //}

        //[HttpGet("GetOrdered")]
        //public IActionResult GetOrdered()
        //{
        //    return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        //}

        //[HttpPost("AddOne")]
        //public IActionResult AddOne()
        //{
        //    var book = _unitOfWork.Books.Add(new Book { Title = "Test 4", AuthorId = 1 });
        //    _unitOfWork.Complete();
        //    return Ok(book);
        //}

    }
}