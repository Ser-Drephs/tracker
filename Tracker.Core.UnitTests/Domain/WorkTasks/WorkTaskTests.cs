using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tracker.Core.Common.WorkTasks;
using Tracker.Core.Domain.WorkItems;

namespace Tracker.Core.Domain.WorkTasks.UnitTests
{
    [TestClass]
    public class WorkTaskTests
    {
        [TestMethod]
        public void Start_Work()
        {
            var workItem = WorkItem.Create("13", "");
            var task = WorkTask.StartWork(workItem, 0);
            task.Should().NotBeNull();
            task.WorkItem.Should().Be(workItem);
            task.Start.Should().BeCloseTo(DateTime.Now);
            task.End.Should().BeNull();
        }

        [TestMethod]
        public void Start_Work_With_Activity()
        {
            var workItem = WorkItem.Create("13", "");
            var task = WorkTask.StartWork(workItem, WorkTaskActivity.Development);
            task.Should().NotBeNull();
            task.WorkItem.Should().Be(workItem);
            task.Start.Should().BeCloseTo(DateTime.Now);
            task.Activity.Should().Be(WorkTaskActivity.Development);
            task.End.Should().BeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(WorkItemEmptyException))]
        public void Start_Work_With_Empty_WorkItem_Exception()
        {
            WorkItem workItem = new WorkItem();
            WorkTask.StartWork(workItem, 0);
        }

        [TestMethod]
        public void End_Work()
        {
            var workItem = WorkItem.Create("12", "");
            var task = WorkTask.StartWork(workItem, 0);
            task = task.EndWork();
            task.End.Should().BeCloseTo(DateTime.Now);
        }

        [TestMethod]
        public void Compare_Test()
        {
            var task1 = WorkTask.StartWork(WorkItem.Create("12", ""), 0);
            var task2 = WorkTask.StartWork(WorkItem.Create("12", ""), 0);
            task2 = task2.EndWork();
            task1.Should().BeEquivalentTo(task2);
            task1.End.Should().BeNull();
            task2.End.Should().NotBeNull();
        }

        [TestMethod]
        public void Compare_Other_Activity_Test()
        {
            var task1 = WorkTask.StartWork(WorkItem.Create("12", ""), 0);
            var task2 = WorkTask.StartWork(WorkItem.Create("12", ""), WorkTaskActivity.Planning);
            task2 = task2.EndWork();
            task1.Should().NotBeEquivalentTo(task2);
            task1.End.Should().BeNull();
            task2.End.Should().NotBeNull();
        }

        [TestMethod]
        public void EqualOp_Test()
        {
            var task1 = WorkTask.StartWork(WorkItem.Create("12", ""), 0);
            var task2 = WorkTask.StartWork(WorkItem.Create("12", ""), 0);
            Assert.IsTrue(task1 == task2);
        }

        [TestMethod]
        public void UnequalOp_Test()
        {
            var task1 = WorkTask.StartWork(WorkItem.Create("12", ""), 0);
            var task2 = WorkTask.StartWork(WorkItem.Create("12", ""), WorkTaskActivity.Requirements);
            Assert.IsTrue(task1 != task2);
        }
    }
}