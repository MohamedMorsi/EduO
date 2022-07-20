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
    public class GradesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Grade> _gradeService;

        public GradesController(IBaseService<Grade> gradeService, IMapper mapper)
        {
            _mapper = mapper;
            _gradeService = gradeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var grades = _gradeService.GetAll();
            var dtos = _mapper.Map<IEnumerable<GradeDto>>(grades);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var grades = await _gradeService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<GradeDto>>(grades);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var grade = _gradeService.GetById(id);
            var dto = _mapper.Map<GradeDto>(grade);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var grade = await _gradeService.GetByIdAsync(id);
            var dto = _mapper.Map<GradeDto>(grade);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(GradeDto dto)
        {
            var grade = _mapper.Map<Grade>(dto);

            _gradeService.Add(grade);

            return Ok(grade);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(GradeDto dto)
        {
            var grade = _mapper.Map<Grade>(dto);

            await _gradeService.AddAsync(grade);

            return Ok(grade);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] GradeDto dto)
        {
            var grade = await _gradeService.GetByIdAsync(id);

            if (grade == null)
                return NotFound($"No grade was found with ID: {id}");

            grade.Name = dto.Name;

            _gradeService.Update(grade);

            return Ok(grade);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var grade = await _gradeService.GetByIdAsync(id);

            if (grade == null)
                return NotFound($"No grade was found with ID: {id}");

            _gradeService.Delete(grade);

            return Ok(grade);
        }

    }
}