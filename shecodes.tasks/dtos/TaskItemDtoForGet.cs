using System;
using shecodes.tasks.models;

namespace shecodes.tasks.dtos
{
    public class TaskItemDtoForGet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? Deadline { get; set; }
        public Priority Priority { get; set; }
        
        public string CreatedBy { get; set; }
        public string AssignedFor { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DoneOn { get; set; }
    }
}