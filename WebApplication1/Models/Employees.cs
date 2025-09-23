using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employees
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Degree { get; set; }
    }

    public class Emp
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Degree { get; set; }
    }

    [Keyless]
    public class Login
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
