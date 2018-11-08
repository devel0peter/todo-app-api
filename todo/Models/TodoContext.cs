using Microsoft.EntityFrameworkCore;

namespace todo.Models
{
	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options) : base(options)
		{

		}

		public DbSet<TodoItem> TodoItems { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Tag>()
				.HasIndex(tag => tag.Name)
				.IsUnique();

			modelBuilder.Entity<TodoItem>().Property(i => i.Name).IsRequired();
			//modelBuilder.Entity<TodoItem>().Property(i => i.User).IsRequired();
			modelBuilder
				.Entity<User>()
				.HasMany(u => u.TodoItems)
				.WithOne(i => i.User)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder
				.Entity<User>()
				.HasData(
				new User { Id = 1, FirstName = "Peter", LastName = "Acs" }
				);

			modelBuilder.Entity<TodoItem>().HasData(
				new TodoItem { Id = 1, Name = "walk dog", UserId = 1 },
				new TodoItem { Id = 2, Name = "walk cat", UserId = 1 },
				new TodoItem { Id = 3, Name = "do the dishes", UserId = 1 },
				new TodoItem { Id = 4, Name = "drink beer", UserId = 1 },
				new TodoItem { Id = 5, Name = "drink wine", UserId = 1 }
				);

			modelBuilder
				.Entity<Tag>()
				.HasData(
				new Tag { Id = 1, Name = "work" },
				new Tag { Id = 2, Name = "home" }
				);
		}
	}
}
