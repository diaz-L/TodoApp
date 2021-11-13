using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApp.Entities.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasData(
                new TodoItem { Id = 1, Text = "task one"},
                new TodoItem { Id = 2, Text = "task two"},
                new TodoItem { Id = 3, Text = "task three"}
            );
        }
    }
}