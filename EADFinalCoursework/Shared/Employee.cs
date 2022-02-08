using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EADFinalCoursework.Shared
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string FrirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ProjectId { get; set; }
    }
}
