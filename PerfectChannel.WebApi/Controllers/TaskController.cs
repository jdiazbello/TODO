using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                id = System.Guid.NewGuid()
            },
            new TaskTodo
            {
                name = "TestTaskDONE",
                completed = true,
                id = System.Guid.NewGuid()
            }

            };

        [HttpGet]
        public List<TaskTodo> Get()
        {
            return taskList;
        }
    }
}