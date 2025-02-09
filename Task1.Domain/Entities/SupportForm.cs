using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Domain.Entities
{
    public enum FormStatus
    {
        Processed,
        Pending,
        Deleted
    }

    public class SupportForm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public FormStatus Status { get; set; } = FormStatus.Pending;


    }
}