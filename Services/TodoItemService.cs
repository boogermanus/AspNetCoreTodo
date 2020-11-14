using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;
        
        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<TodoItem>> GetIncompleteItemsAsync(IdentityUser user)
        {
            return await _context.Items.Where(i => !i.IsDone && i.UserId == user.Id).ToListAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            newItem.UserId = user.Id;

            await _context.Items.AddAsync(newItem);

            var result = await _context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return false;

            item.IsDone = true;

            var result = await _context.SaveChangesAsync();

            return result == 1;
        }
    }
}