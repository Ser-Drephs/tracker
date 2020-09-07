using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.Core.Common.WorkItems;
using Tracker.Core.Domain.WorkItems;

namespace Tracker.Core.Entities.WorkItems.UnitTests
{
    [TestClass]
    public class WorkItemDomainEntityMapperTests
    {
        private readonly WorkItemDomainEntityMapper entityMapper;

        public WorkItemDomainEntityMapperTests()
        {
            entityMapper = new WorkItemDomainEntityMapper();
        }

        [TestMethod]
        public void Map_Domain_Object_With_All_Values_To_Entity()
        {
            var workItem = WorkItem.Create("12", "Sample", WorkItemType.Story);
            var entity = entityMapper.MapToEntity(workItem);
            entity.Should().NotBeNull();
            entity.TaskId.Should().Be("12");
            entity.Description.Should().Be("Sample");
            entity.WorkItemType.Should().Be(3);
        }

        [TestMethod]
        public void Map_Domain_Object_With_Partial_Values_To_Entity()
        {
            var workItem = WorkItem.Create("13", "Not all Values");
            var entity = entityMapper.MapToEntity(workItem);
            entity.Should().NotBeNull();
            entity.TaskId.Should().Be("13");
            entity.Description.Should().Be("Not all Values");
            entity.WorkItemType.Should().Be(0);
        }

        [TestMethod]
        public void Map_Domain_List_To_Entity()
        {
            var domainObjects = new List<WorkItem>()
            {
                { WorkItem.Create("1", "Sample 1", WorkItemType.Feature) },
                { WorkItem.Create("2", "Sample 2", WorkItemType.Bug) },
                { WorkItem.Create("3", "Sample 3", WorkItemType.Story) },
                { WorkItem.Create("4", "Sample 4", WorkItemType.Vision) }
            };
            var entities = entityMapper.MapToEntity(domainObjects);
            entities.Count().Should().Be(4);
            entities.First().WorkItemType.Should().BeOfType(typeof(int));
        }

        [TestMethod]
        public void Map_Entity_With_All_Values_To_Domain()
        {
            var guid = Guid.NewGuid();
            var entity = new WorkItemEntity(){ TaskId = "12", Description = "Sample Entity", WorkItemType = 2, WorkItemId = guid };
            var workItem = entityMapper.MapToDomain(entity);
            workItem.Should().NotBeNull();
            workItem.WorkItemId.Should().Be(guid);
            workItem.TaskId.Should().Be("12");
            workItem.Description.Should().Be("Sample Entity");
            workItem.WorkItemType.Should().Be(WorkItemType.Feature);
        }

        [TestMethod]
        public void Map_Entity_With_Partial_Values_To_Domain()
        {
            var guid = Guid.NewGuid();
            var entity = new WorkItemEntity(){TaskId = "13", Description = "Sample Entity", WorkItemType = 0, WorkItemId = guid};
            var workItem = entityMapper.MapToDomain(entity);
            workItem.Should().NotBeNull();
            workItem.WorkItemId.Should().Be(guid);
            workItem.TaskId.Should().Be("13");
            workItem.Description.Should().Be("Sample Entity");
            workItem.WorkItemType.Should().Be(WorkItemType.Unknown);
        }

        [TestMethod]
        public void Map_Entity_List_To_Domain()
        {
            var entityList = new List<WorkItemEntity>(){
                { new WorkItemEntity() { TaskId = "11", Description = "Sample Entity 1", WorkItemType = 0, WorkItemId = Guid.NewGuid()} },
                { new WorkItemEntity() { TaskId = "12", Description = "Sample Entity 2", WorkItemType = 1, WorkItemId = Guid.NewGuid()} },
                { new WorkItemEntity() { TaskId = "13", Description = "Sample Entity 3", WorkItemType = 2, WorkItemId = Guid.NewGuid()} },
                { new WorkItemEntity() { TaskId = "14", Description = "Sample Entity 4", WorkItemType = 3, WorkItemId = Guid.NewGuid()} },
                { new WorkItemEntity() { TaskId = "15", Description = "Sample Entity 5", WorkItemType = 2, WorkItemId = Guid.NewGuid()} }
            };
            var domainObjects = entityMapper.MapToDomain(entityList);
            domainObjects.Count().Should().Be(5);
            domainObjects.First().TaskId.Should().NotBeNullOrEmpty();
            domainObjects.First().WorkItemType.Should().BeOfType(typeof(WorkItemType));
        }
    }
}