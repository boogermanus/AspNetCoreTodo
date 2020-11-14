using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItemModel>> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> AddItemAsync(AddTodoItemModel newItemModel, IdentityUser user);
        Task<bool> MarkDoneAsync(Guid id);
    }
}