using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Domain.Entities;

namespace Task1.Application.Services
{
    public interface ITokenService
{
    string GenerateToken(User user);
    User ValidateToken(string token);
}

}