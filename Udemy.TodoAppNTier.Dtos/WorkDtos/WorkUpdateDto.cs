using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Dtos.Interfaces;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkUpdateDto:IDto
    {
        //[Range(1,int.MaxValue,ErrorMessage = "Id is required")]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Definition Is required")]
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
