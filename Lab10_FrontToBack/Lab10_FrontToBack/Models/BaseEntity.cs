using System;
using System.ComponentModel.DataAnnotations;

namespace Lab10_FrontToBack.Models
{
	public abstract class BaseEntity
	{
		[Key]
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }

        public BaseEntity()
		{
		}
	}
}

