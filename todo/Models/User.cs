using System.Collections.Generic;

namespace todo.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public List<TodoItem> TodoItems { get; set; }
	}
}
