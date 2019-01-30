using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.User;

namespace TodoApp.Infrastructure.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Task.Task> Tasks { get; set; }
    }
}
