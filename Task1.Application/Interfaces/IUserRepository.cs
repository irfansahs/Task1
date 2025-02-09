using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task1.Domain.Entities;

namespace Task1.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}