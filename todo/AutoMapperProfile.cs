using AutoMapper;
using todo.Models;

namespace todo
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserDto>();
			CreateMap<TodoItem, TodoWithUserDto>();
		}
	}
}
