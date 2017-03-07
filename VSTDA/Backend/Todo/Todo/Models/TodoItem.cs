using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class TodoItem
    {
        public int TodoItemId { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }
    }
}