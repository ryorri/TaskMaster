using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Objects
{
    public class WarningDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public string? Answer { get; set; }
    }
}
