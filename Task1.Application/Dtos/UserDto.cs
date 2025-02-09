using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Domain.Entities;

namespace Task1.Application.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer;
    }
}