using Hasse.Core.ProjectAggregate;

namespace Hasse.Web.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public static ToDoItemViewModel FromToDoItem(ToDoItem item)
        {
            return new()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsDone = item.IsDone
            };
        }
    }
}