using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TodoItemModel> Items { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
