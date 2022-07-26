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
    public class CourseTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<CourseType> _CourseTypeService;

        public CourseTypesController(IBaseService<CourseType> CourseTypeService, IMapper mapper)
        {
            _mapper = mapper;
            _CourseTypeService = CourseTypeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var CourseTypes = _CourseTypeService.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseTypeDto>>(CourseTypes);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var CourseTypes = await _CourseTypeService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<CourseTypeDto>>(CourseTypes);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var CourseType = _CourseTypeService.GetById(id);
            var dto = _mapper.Map<CourseTypeDto>(CourseType);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var CourseType = await _CourseTypeService.GetByIdAsync(id);
            var dto = _mapper.Map<CourseTypeDto>(CourseType);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(CourseTypeDto dto)
        {
            var CourseType = _mapper.Map<CourseType>(dto);

            _CourseTypeService.Add(CourseType);

            return Ok(CourseType);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CourseTypeDto dto)
        {
            var CourseType = _mapper.Map<CourseType>(dto);

            await _CourseTypeService.AddAsync(CourseType);

            return Ok(CourseType);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CourseTypeDto dto)
        {
            var courseType = await _CourseTypeService.GetByIdAsync(id);

            if (courseType == null)
                return NotFound($"No CourseType was found with ID: {id}");

            _mapper.Map(dto, courseType);

            var updatedDto = _CourseTypeService.Update(courseType);

            return Ok(_mapper.Map<CourseTypeDto>(updatedDto));
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var CourseType = await _CourseTypeService.GetByIdAsync(id);

            if (CourseType == null)
                return NotFound($"No CourseType was found with ID: {id}");

            _CourseTypeService.Delete(CourseType);

            return Ok(CourseType);
        }

    }
}