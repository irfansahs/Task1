using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Application.Interfaces;
using Task1.Domain.Entities;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Repositories
{
   public class SupportFormRepository : GenericRepository<SupportForm>, ISupportFormRepository
    {
        public SupportFormRepository(AppDbContext context) : base(context) { }

        public Task<IEnumerable<SupportForm>> GetByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }
    }
}