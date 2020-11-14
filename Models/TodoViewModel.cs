using System.Collections.Generic;

namespace AspNetCoreTodo.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItemModel> Items { get; set; }
    }
}