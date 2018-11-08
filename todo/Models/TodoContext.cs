using Microsoft.EntityFrameworkCore;

namespace todo.Models
{
	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options) : base(options)
		{

		}

		public DbSet<TodoItem> TodoItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TodoItem>().HasData(
				new TodoItem { Id = 1, Name = "walk dog" },
				new TodoItem { Id = 2, Name = "walk cat" },
				new TodoItem { Id = 3, Name = "do the dishes" },
				new TodoItem { Id = 4, Name = "drink beer" },
				new TodoItem { Id = 5, Name = "drink wine" }
				);
		}
	}
}
