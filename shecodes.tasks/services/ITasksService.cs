using System;
using System.Collections.Generic;
using shecodes.tasks.Filters;
using shecodes.tasks.models;

namespace shecodes.tasks.services
{
    public interface ITasksService
    {
        void AddTaskItem(TaskItem taskItem);
        List<TaskItem> GetTaskItems();

        List<TaskItem> ByCreatedBy(String createdBy);

        List<TaskItem> SearchFilterDate(TasksSearchFilter filter, int y);
    }
}