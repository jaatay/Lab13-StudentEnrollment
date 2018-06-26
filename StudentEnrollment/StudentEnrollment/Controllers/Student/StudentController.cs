using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollment.Controllers.Student
{
    public class StudentController: Controller
    {
		private SpyDBContext _context;

		public StudentController(SpyDBContext context)
		{
			_context = context;
		}

		//search
		public async Task<IActionResult> SearchResult(string searchString)
		{
			var students = from m in _context.Students
						  select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				students = students.Where(s => s.Name.Contains(searchString));
			}

			return View(await students.ToListAsync());
		}

		//create
		public async Task<IActionResult> Create()
		{
			ViewData["Courses"] = await _context.Courses.Select(x => x)
				.ToListAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("ID, Name, SpyAlias, CourseId")]StudentEnrollment.Models.Student student)
		{
			_context.Students.Add(student);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Home");
		}

		//read

		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{

				return View(await _context.Students.Where(s => s.ID == id)
					.SingleAsync());
			}
			return View();

		}
		public async Task<IActionResult> ViewAll()
		{
			var data = await _context.Students.Include(s => s.Course).ToListAsync();

			return View(data);
		}

		//update
		[HttpGet]
		public async Task<IActionResult> Update(int? id)
		{
			if (id.HasValue)
			{
				Models.Student student = await _context.Students.FirstOrDefaultAsync(a => a.ID == id);
				return View(student);
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Update([Bind("ID, Name, SpyAlias, CourseId")]Models.Student student)
		{
			_context.Students.Update(student);

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}

		//delete
		public async Task<IActionResult> Delete(int id)
		{
			var student = await _context.Students.FindAsync(id);


			if (student == null)
			{
				return NotFound();
			}

			_context.Students.Remove(student);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
