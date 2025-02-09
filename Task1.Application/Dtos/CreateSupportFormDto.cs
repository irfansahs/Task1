using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Domain.Entities;

namespace Task1.Application.Dtos
{
    public class CreateSupportFormDto
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}