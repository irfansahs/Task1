using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Application.Dtos;
using Task1.Domain.Entities;

namespace Task1.Application.Services
{
    public interface ISupportFormService
    {
        Task<IEnumerable<SupportForm>> GetAllAsync();
        Task<SupportForm> GetByIdAsync(Guid id);
        Task<IEnumerable<SupportForm>> GetByStatusAsync(string status);
        Task AddAsync(CreateSupportFormDto dto);
        Task UpdateAsync(UpdateSupportFormDto supportForm);
        Task DeleteAsync(Guid id);
    }

}