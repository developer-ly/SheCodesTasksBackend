using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shecodes.tasks.data;
using shecodes.tasks.Filters;
using shecodes.tasks.models;

namespace shecodes.tasks.services
{
    public class TasksService : ITasksService
    {
        private readonly ApplicationDbContext _context;

        public TasksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTaskItem(TaskItem taskItem)
        {
            var adjustedItem = taskItem;
            adjustedItem.CreatedOn = DateTime.UtcNow;
            _context.TaskItems.Add(taskItem);
        }

        public List<TaskItem> GetTaskItems()
        {
            return _context.TaskItems.ToList();
        }


        public List<TaskItem> ByCreatedBy(string createdBy)
        {
            return _context.TaskItems
                .Where(x => Equals(x.CreatedBy, createdBy))
                .ToList();
        }

      

        public List<TaskItem> SearchFilterDate(TasksSearchFilter filter, int y)
        {
            switch (y)
            {
                case 1: return _context.TaskItems.Where(x => Equals(x.CreatedOn, filter.CreatedOn)).ToList();
                    break;
                case 2: return _context.TaskItems.Where(x => Equals(x.DoneOn, filter.DoneOn)).ToList();
                    break;
                case 3: return _context.TaskItems.Where(x => Equals(x.Deadline, filter.Deadline)).ToList();
                    break;
                default:
                    return new List<TaskItem>();
                    break;
            }
            


        }
    }
}