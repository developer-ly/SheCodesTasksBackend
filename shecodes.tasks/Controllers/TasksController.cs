using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shecodes.tasks.data;
using shecodes.tasks.dtos;
using shecodes.tasks.Filters;
using shecodes.tasks.models;
using shecodes.tasks.services;

namespace shecodes.tasks.Controllers
{
    [Route("api/tasks")]
    public class TasksController : ShecodesBaseController
    {
        private readonly ITasksService _tasksService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TasksController(ITasksService tasksService, ApplicationDbContext context, IMapper mapper)
        {
            _tasksService = tasksService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        { 
            var content = _mapper.Map<List<TaskItemDtoForGet>>(_tasksService.GetTaskItems());
            return Ok(content);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDtoForPost task)
        {
            var entity = _mapper.Map<TaskItem>(task);
            _tasksService.AddTaskItem(entity);
            
            if (await _context.SaveChangesAsync() == 0)
            {
                // return new ObjectResult(StatusCodes.Status304NotModified));
                return BadRequest("couldn't save the new task"); 
            }
            return Ok();
        }

        [HttpGet("byCreatedBy")]
        public IActionResult SearchByCreatedBy([FromQuery] string createdBy)
        {
            var result = _tasksService.ByCreatedBy(createdBy);
            
            return Ok(result);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] TasksSearchFilter filter, int y)
        {
            var result = _tasksService.SearchFilterDate(filter, y);
            
            return BadRequest();
        }
    }
}