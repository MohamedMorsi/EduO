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
    public class ExClassController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<ExClass> _ExClassService;

        public ExClassController(IBaseService<ExClass> ExClassService, IMapper mapper)
        {
            _mapper = mapper;
            _ExClassService = ExClassService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var ExClasss = _ExClassService.GetAll();
            var dtos = _mapper.Map<IEnumerable<ExClassDto>>(ExClasss);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var ExClasss = await _ExClassService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ExClassDto>>(ExClasss);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var ExClass = _ExClassService.GetById(id);
            var dto = _mapper.Map<ExClassDto>(ExClass);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ExClass = await _ExClassService.GetByIdAsync(id);
            var dto = _mapper.Map<ExClassDto>(ExClass);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(ExClassDto dto)
        {
            var ExClass = _mapper.Map<ExClass>(dto);

            _ExClassService.Add(ExClass);

            return Ok(ExClass);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(ExClassDto dto)
        {
            var ExClass = _mapper.Map<ExClass>(dto);

            await _ExClassService.AddAsync(ExClass);

            return Ok(ExClass);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExClassDto dto)
        {
            var ExClass = await _ExClassService.GetByIdAsync(id);

            if (ExClass == null)
                return NotFound($"No ExClass was found with ID: {id}");

            ExClass.Name = dto.Name;

            _ExClassService.Update(ExClass);

            return Ok(ExClass);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ExClass = await _ExClassService.GetByIdAsync(id);

            if (ExClass == null)
                return NotFound($"No ExClass was found with ID: {id}");

            _ExClassService.Delete(ExClass);

            return Ok(ExClass);
        }

    }
}