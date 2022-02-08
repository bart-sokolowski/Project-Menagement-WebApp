using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EADFinalCoursework.Shared
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
