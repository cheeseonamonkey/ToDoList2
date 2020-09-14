using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList2.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public bool Completed { get; set; }

    }
}
