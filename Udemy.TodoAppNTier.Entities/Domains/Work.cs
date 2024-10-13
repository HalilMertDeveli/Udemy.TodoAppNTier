using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Entities.Domains
{
    public class Work
    {
        public int Id { get; set; }
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
