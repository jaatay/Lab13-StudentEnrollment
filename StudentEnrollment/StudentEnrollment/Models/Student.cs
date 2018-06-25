﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Student
    {
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name="Spy Alias")]
		public string SpyAlias { get; set; }

		[Required]
		public int Age { get; set; }

		[Required]
		public int CourseId { get; set; }
    }
}
