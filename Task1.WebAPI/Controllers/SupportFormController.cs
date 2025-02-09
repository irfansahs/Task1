using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task1.Application.Dtos;
using Task1.Application.Interfaces;
using Task1.Application.Services;
using Task1.Domain.Entities;

namespace Task1.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportFormController : ControllerBase
    {
        private readonly ISupportFormService _supportFormService;

        public SupportFormController(ISupportFormService supportFormService)
        {
            _supportFormService = supportFormService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var forms = await _supportFormService.GetAllAsync();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var form = await _supportFormService.GetByIdAsync(id);
            return Ok(form);
        }


        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateSupportForm([FromBody] CreateSupportFormDto dto)
        {
            await _supportFormService.AddAsync(dto);
            return Ok();
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateSupportFormDto supportForm)
        {
            await _supportFormService.UpdateAsync(supportForm);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _supportFormService.DeleteAsync(id);
            return NoContent();
        }
    }

}