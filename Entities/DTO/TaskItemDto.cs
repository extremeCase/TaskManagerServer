using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class TaskItemDto
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? priority { get; set; }
        public DateTime dueDate { get; set; }
        public string? status { get; set; }
    }
}
