using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDto
    {
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
