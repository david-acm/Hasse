using System.Collections.Generic;

namespace Hasse.Web.ViewModels
{
    public class ProjectViewModel
    {
        public List<ToDoItemViewModel> Items = new();
        public int Id { get; set; }
        public string Name { get; set; }
    }
}