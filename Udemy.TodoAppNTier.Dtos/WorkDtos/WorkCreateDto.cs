using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDto
    {
        [Required(ErrorMessage = "Definition is required")]
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
