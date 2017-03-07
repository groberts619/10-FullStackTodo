using System;
using System.Collections.Generic;
using System.Data.Entity;
using Todo.Models;
using System.Linq;
using System.Web;

namespace Todo.Infrastructure
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext() : base("Todo")
        {

        }
        public IDbSet<TodoItem> TodoItems { get; set; }
    }
}