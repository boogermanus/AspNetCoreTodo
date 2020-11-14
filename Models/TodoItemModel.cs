﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Models
{
    public class TodoItemModel
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        [Required] public string Title { get; set; }
        public DateTimeOffset DueAt { get; set; }
        public string UserId { get; set; }
    }
}