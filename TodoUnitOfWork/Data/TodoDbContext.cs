using System;
using Microsoft.EntityFrameworkCore;
using TodoUnitOfWork.Models;

namespace TodoUnitOfWork.Data
{
	public class TodoDbContext : DbContext
	{
		public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
		{

		}
		public DbSet<TodoTask> TodoTasks { get; set; }
	}
}

