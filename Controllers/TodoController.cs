using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;
        
        public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var items = await _todoItemService.GetIncompleteItemsAsync(user);
            
            return View(new TodoViewModel{Items = items});
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddItem(AddTodoItemModel newItemModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var user = await _userManager.GetUserAsync(User);
            var successful = await _todoItemService.AddItemAsync(newItemModel, user);

            if (!successful)
                return BadRequest("Could not add item.");

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                return RedirectToAction("Index");

            var successful = await _todoItemService.MarkDoneAsync(id);

            if (!successful)
                return BadRequest("Could not mark item as done.");

            return RedirectToAction("Index");
        }
    }
}