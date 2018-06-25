using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class SpyDBContext: DbContext
    {
		public SpyDBContext(DbContextOptions<SpyDBContext> options) : base(options)
		{
			
		}

		public DbSet<Course>Courses { get; set; }
		public DbSet<Student>Students { get; set; }
    }
}
