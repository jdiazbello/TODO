using NUnit.Framework;
using PerfectChannel.WebApi;
using PerfectChannel.WebApi.Controllers;
using System.Collections.Generic;

namespace Task.UnitTests
{
    [TestFixture]
    public class TastTest
    {
        private PerfectChannel.WebApi.Controllers.Task _taskController;

        [SetUp]
        public void SetUp()
        {
            _taskController = new PerfectChannel.WebApi.Controllers.Task();
        }

        [TearDown]
        public void Cleanup()
        {
            _taskController.CleanList();
        }


        [Test]
        public void GetTaskListEmpty()
        {
            var list = _taskController.Get();
            Assert.IsInstanceOf<List<TaskTodo>>(list);
            Assert.AreEqual(list.Count,0);
        }

        [Test]
        public void AddNullTask()
        {
            var result = _taskController.Post(null);

            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(result);         
        }

        [Test]
        public void AddTask()
        {
            var result = _taskController.Post(new TaskTodo {name ="TaskTest" });
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            var list = _taskController.Get();
            Assert.AreEqual(list.Count, 1);
        }
    }
}