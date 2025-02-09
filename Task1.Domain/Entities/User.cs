using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Domain.Entities
{
    public enum UserRole
    {
        Admin,
        Customer
    }
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer;
        public ICollection<SupportForm>? SupportForms { get; set; }
    }
}