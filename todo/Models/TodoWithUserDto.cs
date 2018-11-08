namespace todo.Models
{
	public class TodoWithUserDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsComplete { get; set; }
		public UserDto User { get; set; }
	}
}
