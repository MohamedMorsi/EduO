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
    public class FeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Fee> _FeeService;

        public FeesController(IBaseService<Fee> FeeService, IMapper mapper)
        {
            _mapper = mapper;
            _FeeService = FeeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Fees = _FeeService.GetAll();
            var dtos = _mapper.Map<IEnumerable<FeeDto>>(Fees);

            return Ok(dtos);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Fees = await _FeeService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<FeeDto>>(Fees);

            return Ok(dtos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var Fee = _FeeService.GetById(id);
            var dto = _mapper.Map<FeeDto>(Fee);

            return Ok(dto);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Fee = await _FeeService.GetByIdAsync(id);
            var dto = _mapper.Map<FeeDto>(Fee);

            return Ok(dto);
        }

        [HttpPost("Create")]
        public IActionResult Create(FeeDto dto)
        {
            var Fee = _mapper.Map<Fee>(dto);

            _FeeService.Add(Fee);

            return Ok(Fee);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(FeeDto dto)
        {
            var Fee = _mapper.Map<Fee>(dto);

            await _FeeService.AddAsync(Fee);

            return Ok(Fee);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] FeeDto dto)
        {
            var Fee = await _FeeService.GetByIdAsync(id);

            if (Fee == null)
                return NotFound($"No Fee was found with ID: {id}");

            _mapper.Map(dto, Fee);

            var UpdatedDto = _FeeService.Update(Fee);

            return Ok(Fee);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Fee = await _FeeService.GetByIdAsync(id);

            if (Fee == null)
                return NotFound($"No Fee was found with ID: {id}");

            _FeeService.Delete(Fee);

            return Ok(Fee);
        }

    }
}