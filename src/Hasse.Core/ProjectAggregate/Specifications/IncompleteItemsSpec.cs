using Ardalis.Specification;

namespace Hasse.Core.ProjectAggregate.Specifications
{
    public sealed class IncompleteItemsSpec : Specification<ToDoItem>
    {
        public IncompleteItemsSpec()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}