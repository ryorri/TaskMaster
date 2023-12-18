using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Objects
{
    public class ErrorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        //public Category? Category { get; set; }
        public int PriorityId { get; set; }
        //public Priority? Priority { get; set; }
        public string? Answer { get; set; }
        public string UserId { get; set; }
    }
}
