using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class Task : ControllerBase
    {
        //private static List<TaskTodo> taskList = new List<TaskTodo>{
        //    new TaskTodo
        //    {
        //        name = "TestTaskTODO",
        //        completed = false,
        //        id = System.Guid.NewGuid()
        //    },
        //    new TaskTodo
        //    {
        //        name = "TestTaskDONE",
        //        completed = true,
        //        id = System.Guid.NewGuid()
        //    }
        //    };

        private static List<TaskTodo> taskList = new List<TaskTodo>();

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
                return StatusCode(500,"Internal Server Error");
            }
        }

        public void CleanList()
        {
            taskList = new List<TaskTodo>();
        }

    }
}