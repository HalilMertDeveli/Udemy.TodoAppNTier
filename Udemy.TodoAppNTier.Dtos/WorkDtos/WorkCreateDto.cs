﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Dtos.Interfaces;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDto:IDto
    {
        //[Required(ErrorMessage = "Definition is required")]
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
