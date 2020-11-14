using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class AddTodoItemModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int DaysUntil { get; set; }
    }
}