using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList2.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> o)
            :base(o)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
