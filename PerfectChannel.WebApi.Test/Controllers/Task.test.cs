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

        [Test]
        public void GetTaskListEmpty()
        {
            var list = _taskController.Get();
            Assert.IsNotInstanceOf(list.GetType(), typeof(List<TaskTodo>));
            Assert.AreEqual(list.Count,0);
        }
    }
}