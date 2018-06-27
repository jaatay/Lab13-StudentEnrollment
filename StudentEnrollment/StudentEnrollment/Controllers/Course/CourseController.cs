using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollment.Controllers.Course
{
	public class CourseController : Controller
	{
		private SpyDBContext _context;

		public CourseController(SpyDBContext context)
		{
			_context = context;
		}

		//search
		public async Task<IActionResult> SearchResult(string searchString)
		{
			var courses = from m in _context.Courses
						 select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				courses = courses.Where(s => s.Name.Contains(searchString));
			}

			return View(await courses.ToListAsync());
		}

		//create
		public async Task<IActionResult> Create()
		{
			ViewData["Courses"] = await _context.Courses.Select(x => x)
				.ToListAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("ID, Name, Level, Category")]StudentEnrollment.Models.Course course)
		{
			
			_context.Courses.Add(course);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Home");
		}

		//read

		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{
				//pretty sure i got the data i wanted here, but not sure how to get it to the page
				var students =_context.Students.Where(x => x.CourseId == id).ToList();

				return View(await _context.Courses.Where(s => s.ID == id)
					//.Include(students.ToString())
					.SingleAsync());
			}
			return View();

		}
		public async Task<IActionResult> ViewAll()
		{
			var data = await _context.Courses
				
				.ToListAsync();
	
			return View(data);

		}

		//update
		[HttpGet]
		public async Task<IActionResult> Update(int? id)
		{
			if (id.HasValue)
			{
				Models.Course course = await _context.Courses.FirstOrDefaultAsync(a => a.ID == id);
				return View(course);
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Update([Bind("ID, Name, Level, Category")]Models.Course course)
		{
			_context.Courses.Update(course);

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}

		//delete
		public async Task<IActionResult> Delete(int id)
		{
			var course = await _context.Courses.FindAsync(id);


			if (course == null)
			{
				return NotFound();
			}

			_context.Courses.Remove(course);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}
	}

}
