﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoApiController : ControllerBase
	{
		private readonly TodoContext _context;
		private readonly IMapper _mapper;

		public TodoApiController(TodoContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<List<TodoWithUserDto>> GetAll()
		{
			var todoItems = await _context
				.TodoItems
				.Include(i => i.User)
				.AsNoTracking()
				.ToListAsync()
				.ConfigureAwait(false);

			return _mapper.Map<List<TodoWithUserDto>>(todoItems);

			//return todoItems.Select(i => new TodoWithUserDto
			//{
			//	Id = i.Id,
			//	Name = i.Name,
			//	IsComplete = i.IsComplete,
			//	User = new UserDto
			//	{
			//		Id = i.User.Id,
			//		FirstName = i.User.FirstName,
			//		LastName = i.User.LastName
			//	}
			//})
			//.ToList();
		}

		[HttpGet("{id}", Name = "GetTodo")]
		public async Task<ActionResult<TodoItem>> GetById(int id)
		{
			var item = await _context.TodoItems.FindAsync(id).ConfigureAwait(false);
#pragma warning disable RCS1173 // Use coalesce expression instead of if.
			if (item == null)
			{
				return NotFound();
			}
#pragma warning restore RCS1173 // Use coalesce expression instead of if.
			return item;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(TodoItem item)
		{
			_context.TodoItems.Add(item);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, TodoItem item)
		{
			var todo = await _context.TodoItems.FindAsync(id).ConfigureAwait(false);
			if (todo == null)
			{
				return NotFound();
			}

			todo.IsComplete = item.IsComplete;
			todo.Name = item.Name;

			_context.TodoItems.Update(todo);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var todo = await _context.TodoItems.FindAsync(id).ConfigureAwait(false);
			if (todo == null)
			{
				return NotFound();
			}

			_context.TodoItems.Remove(todo);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			return NoContent();
		}
	}
}
