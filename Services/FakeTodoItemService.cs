using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<List<TodoItemModel>> GetIncompleteItemsAsync(IdentityUser user)
        {
            var list = new List<TodoItemModel>
            {
                new TodoItemModel
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItemModel
                {
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }

            };

            return Task.FromResult(list);
        }

        public Task<bool> AddItemAsync(AddTodoItemModel newItemModel, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkDoneAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}