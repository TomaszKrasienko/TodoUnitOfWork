using System;
using System.ComponentModel.DataAnnotations;

namespace TodoUnitOfWork.Models
{
	public class TodoTask
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Content { get; set; } = string.Empty;
		public DateTime? EndTime { get; set; }
		[Required]
		public bool IsDone { get; set; }
	}
}

