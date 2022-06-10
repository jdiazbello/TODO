using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class Task : ControllerBase
    {
        private static List<TaskTodo> taskList = new List<TaskTodo>{
            new TaskTodo
            {
                name = "TestTaskTODO",
                completed = false,
                id = Guid.NewGuid()
            },
            new TaskTodo
            {
                name = "TestTaskDONE",
                completed = true,
                id = Guid.NewGuid()
            }
            };

        //private static List<TaskTodo> taskList = new List<TaskTodo>();

        [HttpGet]
        public List<TaskTodo> Get()
        {   
            return taskList;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskTodo obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest("The object is null.");
                obj.id = Guid.NewGuid();
                obj.completed = false;
                taskList.Add(obj);
                return Ok(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }


        [HttpPatch]
        public IActionResult Patch(Guid id, TaskTodo todoTask)
        {
            try
            {
                var tasktoUpdate = taskList.Where(t => t.id == id).FirstOrDefault();

                if (tasktoUpdate == null)
                    return NotFound($"Task with Id = {id} not found");

                tasktoUpdate.completed = todoTask.completed;
                return Ok(tasktoUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating taskList");
            }
        }

        public void CleanList()
        {
            taskList = new List<TaskTodo>();
        }

    }
}