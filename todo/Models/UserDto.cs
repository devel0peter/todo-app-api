﻿namespace todo.Models
{
	public class UserDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName => $"{FirstName} {LastName}";
	}
}
