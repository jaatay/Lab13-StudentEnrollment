using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Course
    {
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public Level Level { get; set; }

		[Required]
		public Category Category { get; set; }

		
    }

	public enum Level
	{
		Beginner,
		Intermediate,
		Advanced,
	}

	public enum Category
	{
		Espionage,
		Sabotage,
		Assassination
	}
}
