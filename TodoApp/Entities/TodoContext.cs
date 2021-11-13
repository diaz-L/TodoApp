using Microsoft.EntityFrameworkCore;
using TodoApp.Entities.Configurations;

namespace TodoApp.Entities
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }

        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}