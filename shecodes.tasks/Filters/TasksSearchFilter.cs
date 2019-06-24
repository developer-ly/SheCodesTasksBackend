using System;

namespace shecodes.tasks.Filters
{
    public class TasksSearchFilter
    {
        public DateTime CreatedOn { get; set; }
        public DateTime DoneOn { get; set; }
        public DateTime Deadline { get; set; }
    }
}