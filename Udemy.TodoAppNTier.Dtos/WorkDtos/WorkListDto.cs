﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
