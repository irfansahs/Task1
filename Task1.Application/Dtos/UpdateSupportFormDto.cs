using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Domain.Entities;

namespace Task1.Application.Dtos
{
    public class UpdateSupportFormDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public FormStatus Status { get; set; }
    }
}