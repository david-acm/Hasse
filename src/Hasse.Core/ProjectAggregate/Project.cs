using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.Core.ProjectAggregate.Events;
using Hasse.SharedKernel;
using Hasse.SharedKernel.Interfaces;

namespace Hasse.Core.ProjectAggregate
{
    public class Project : BaseEntity, IAggregateRoot
    {
        private readonly List<ToDoItem> _items = new();

        public Project(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }

        public string Name { get; private set; }
        public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
        public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

        public void AddItem(ToDoItem newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateName(string newName)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
    }
}