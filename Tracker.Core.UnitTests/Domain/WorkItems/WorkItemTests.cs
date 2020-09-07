using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tracker.Core.Common.WorkItems;

namespace Tracker.Core.Domain.WorkItems.UnitTests
{
    [TestClass]
    public class WorkItemTests
    {
        [TestMethod]
        public void Create_With_Two_Parameters()
        {
            var workitem = WorkItem.Create("12", "Sample");
            workitem.Should().NotBeNull();
            workitem.WorkItemId.Should().NotBe(Guid.Empty);
            workitem.TaskId.Should().Be("12");
            workitem.WorkItemType.Should().Be(WorkItemType.Unknown);
        }

        [TestMethod]
        public void Create_With_Three_Parameters()
        {
            var workitem = WorkItem.Create("12", "Sample", WorkItemType.Bug);
            workitem.Should().NotBeNull();
            workitem.WorkItemId.Should().NotBe(Guid.Empty);
            workitem.TaskId.Should().Be("12");
            workitem.WorkItemType.Should().Be(WorkItemType.Bug);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_Without_TaskId_Exception()
        {
            WorkItem.Create(null, "Sample");
        }

        [TestMethod]
        public void Compare_TaskId_Difference()
        {
            var workitem1 = WorkItem.Create("12", "Description", 0);
            var workitem2 = WorkItem.Create("13", "Other Description", 0);
            workitem1.Should().NotBeEquivalentTo(workitem2);
        }

        [TestMethod]
        public void Compare_WorkItemType_Difference()
        {
            var workitem1 = WorkItem.Create("12", "Description", WorkItemType.Unknown);
            var workitem2 = WorkItem.Create("12", "Other Description", WorkItemType.Vision);
            workitem1.Should().NotBeEquivalentTo(workitem2);
        }

        [TestMethod]
        public void IsEmpty_Test()
        {
            var workitem = new WorkItem();
            workitem.IsEmpty().Should().Be(true);
            workitem.TaskId.Should().Be(null);
            workitem.WorkItemId.Should().Be(Guid.Empty);
        }

        [TestMethod]
        public void Compare_Test()
        {
            var workitem1 = WorkItem.Create("12", "Description", WorkItemType.Feature);
            var workitem2 = WorkItem.Create("12", "Other Description", WorkItemType.Feature);
            workitem1.Should().BeEquivalentTo(workitem2);
        }

        [TestMethod]
        public void EqualOp_Test()
        {
            var workitem1 = WorkItem.Create("12", "Description", WorkItemType.Feature);
            var workitem2 = WorkItem.Create("12", "Other Description", WorkItemType.Feature);
            Assert.IsTrue(workitem1 == workitem2);
        }

        [TestMethod]
        public void UnequalOp_Test()
        {
            var workitem1 = WorkItem.Create("12", "Description", WorkItemType.Feature);
            var workitem2 = WorkItem.Create("13", "Other Description", WorkItemType.Feature);
            Assert.IsTrue(workitem1 != workitem2);
        }
    }
}