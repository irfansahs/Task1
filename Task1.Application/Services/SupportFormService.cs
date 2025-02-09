using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Task1.Application.Dtos;
using Task1.Application.Interfaces;
using Task1.Domain.Entities;

namespace Task1.Application.Services
{
    public class SupportFormService : ISupportFormService
    {
        private readonly ISupportFormRepository _supportFormRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SupportFormService(
            ISupportFormRepository supportFormRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _supportFormRepository = supportFormRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid GetUserIdFromToken()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı!");

            return Guid.Parse(userIdClaim.Value);
        }

        public async Task<IEnumerable<SupportForm>> GetAllAsync()
        {
            return await _supportFormRepository.GetAllAsync();
        }

        public async Task<SupportForm> GetByIdAsync(Guid id)
        {
            return await _supportFormRepository.GetByConditionAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SupportForm>> GetByStatusAsync(string status)
        {
            return await _supportFormRepository.GetByStatusAsync(status);
        }

        public async Task AddAsync(CreateSupportFormDto dto)
        {
            var userId = GetUserIdFromToken();
            var supportForm = _mapper.Map<SupportForm>(dto);
            supportForm.UserId = userId;

            await _supportFormRepository.AddAsync(supportForm);
        }

        public async Task UpdateAsync(UpdateSupportFormDto dto)
        {
            var existingForm = await _supportFormRepository.GetByIdAsync(dto.Id);
            if (existingForm == null)
                throw new KeyNotFoundException("Support form bulunamadı!");

            existingForm.Subject = dto.Subject;
            existingForm.Message = dto.Message;
            existingForm.Status = dto.Status;

            await _supportFormRepository.UpdateAsync(existingForm);
        }


        public async Task DeleteAsync(Guid id)
        {
            var supportForm = await _supportFormRepository.GetByConditionAsync(s => s.Id == id);
            if (supportForm != null)
            {
                await _supportFormRepository.DeleteAsync(supportForm.Id);
            }
        }
    }
}
