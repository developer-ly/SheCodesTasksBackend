using System;
using System.ComponentModel.DataAnnotations;
using shecodes.tasks.models;

namespace shecodes.tasks.dtos
{
    public class TaskDtoForPost
    {
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? Deadline { get; set; }
        public Priority Priority { get; set; } = Priority.Medium;
        public string CreatedBy { get; set; }
    }

//    public class BaseDto
//    {
//        public string CreatedBy { get; set; }
//        public DateTime CreatedOn { get; set; }
//        public string LastModified { get; set; }
//        public DateTime LastModifiedOn { get; set; }
//    }
}