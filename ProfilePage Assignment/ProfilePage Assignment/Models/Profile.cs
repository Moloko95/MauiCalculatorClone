using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilePage_Assignment.Models
{
    public class Profile
    {
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;
    }
}
