using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Common.WorkTasks;
using Tracker.Core.Domain.WorkItems;
using Tracker.Core.Domain.WorkTasks;

namespace Tracker.Core.Entities.WorkTasks.UnitTests
{
    [TestClass]
    public class WorkTaskDomainEntityMapperTests
    {
        private readonly WorkTaskDomainEntityMapper entityMapper;

        public WorkTaskDomainEntityMapperTests()
        {
            entityMapper = new WorkTaskDomainEntityMapper();
        }

        [TestMethod]
        public void Map_Domain_Object_With_All_Values_To_Entity()
        {
            var workitem = WorkItem.Create("123", "Sample", WorkItemType.Story);
            var startTime = DateTime.Now;
            var task = WorkTask.StartWork(workitem, 0);
            task = task.EndWork();
            var entity = entityMapper.MapToEntity(task);
            entity.Should().NotBeNull();
            entity.TaskId.Should().Be("123");
            entity.Activity.Should().Be((int)WorkTaskActivity.None);
            entity.Start.Should().BeCloseTo(startTime);
            entity.End.Should().NotBeNull();
        }

        [TestMethod]
        public void Map_Domain_Object_With_Partial_Values_To_Entity()
        {
            var workitem = WorkItem.Create("123", "Sample", WorkItemType.Story);
            var startTime = DateTime.Now;
            var task = WorkTask.StartWork(workitem, 0);
            var entity = entityMapper.MapToEntity(task);
            entity.Should().NotBeNull();
            entity.TaskId.Should().Be("123");
            entity.Activity.Should().Be((int)WorkTaskActivity.None);
            entity.Start.Should().BeCloseTo(startTime);
            entity.End.Should().BeNull();
        }

        [TestMethod]
        public void Map_Domain_List_To_Entity()
        {
            var workItem = WorkItem.Create("123", "Sample", WorkItemType.Story);
            var domainObjects = new List<WorkTask>()
            {
                { WorkTask.StartWork(workItem, 0) },
                { WorkTask.StartWork(workItem, WorkTaskActivity.Development) },
                { WorkTask.StartWork(workItem, WorkTaskActivity.Requirements) },
                { WorkTask.StartWork(workItem, WorkTaskActivity.Planning) }
            };
            var entities = entityMapper.MapToEntity(domainObjects);
            entities.Count().Should().Be(4);
            entities.First().Activity.Should().BeOfType(typeof(int));
            entities.First().TaskId.Should().Be("123");
        }

        [TestMethod]
        public void Map_Entity_With_All_Values_To_Domain()
        {
            var guid = Guid.NewGuid();
            var entitiy = new WorkTaskEntity(){ Description = "Sample", End = DateTime.Now.AddMinutes(29), Start = DateTime.Now, TaskId = "abc", Activity = 1, WorkItemType = 2, WorkTaskId = guid };
            var domain = entityMapper.MapToDomain(entitiy);
            domain.Should().NotBeNull();
            domain.WorkItem.Should().NotBeNull();
            domain.End.Should().NotBeNull();
            domain.WorkTaskId.Should().Be(guid);
            domain.WorkItem.TaskId.Should().Be("abc");
            domain.Activity.Should().Be(WorkTaskActivity.Development);
            domain.WorkItem.WorkItemType.Should().Be(WorkItemType.Feature);
        }

        [TestMethod]
        public void Map_Entity_With_Partial_Values_To_Domain()
        {
            var guid = Guid.NewGuid();
            var entitiy = new WorkTaskEntity(){ Description = "Sample", End = null, Start = DateTime.Now, TaskId = "abc", WorkTaskId = guid };
            var domain = entityMapper.MapToDomain(entitiy);
            domain.Should().NotBeNull();
            domain.WorkItem.Should().NotBeNull();
            domain.End.Should().BeNull();
            domain.WorkTaskId.Should().Be(guid);
            domain.WorkItem.TaskId.Should().Be("abc");
            domain.Activity.Should().Be(WorkTaskActivity.None);
            domain.WorkItem.WorkItemType.Should().Be(WorkItemType.Unknown);
        }

        [TestMethod]
        public void Map_Entity_List_To_Domain()
        {
            var entites = new List<WorkTaskEntity>()
            {
                { new WorkTaskEntity(){ Description = "Sample 1", End = null, Start = DateTime.Now, TaskId = "1", WorkTaskId = Guid.NewGuid(), Activity = 1, WorkItemType = 1 } },
                { new WorkTaskEntity(){ Description = "Sample 2", End = null, Start = DateTime.Now, TaskId = "2", WorkTaskId = Guid.NewGuid(), Activity = 2, WorkItemType = 2 } },
                { new WorkTaskEntity(){ Description = "Sample 3", End = null, Start = DateTime.Now, TaskId = "3", WorkTaskId = Guid.NewGuid(), Activity = 3, WorkItemType = 3 } },
                { new WorkTaskEntity(){ Description = "Sample 4", End = null, Start = DateTime.Now, TaskId = "4", WorkTaskId = Guid.NewGuid(), Activity = 0, WorkItemType = 4 } }
            };
            var domainObjects = entityMapper.MapToDomain(entites);
            domainObjects.Count().Should().Be(4);
            domainObjects.First().Activity.Should().BeOfType(typeof(WorkTaskActivity));
            domainObjects.First().WorkItem.Should().NotBeNull();
            domainObjects.First().WorkItem.WorkItemType.Should().BeOfType(typeof(WorkItemType));
        }
    }
}