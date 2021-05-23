using System;
using Hasse.Core.ProjectAggregate;
using Xunit;

namespace Hasse.UnitTests.Core.ProjectAggregate
{
    public class Project_AddItem
    {
        private readonly Project _testProject = new("some name");

        [Fact]
        public void AddsItemToItems()
        {
            var _testItem = new ToDoItem
            {
                Title = "title",
                Description = "description"
            };

            _testProject.AddItem(_testItem);

            Assert.Contains(_testItem, _testProject.Items);
        }

        [Fact]
        public void ThrowsExceptionGivenNullItem()
        {
            Action action = () => _testProject.AddItem(null);

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newItem", ex.ParamName);
        }
    }
}