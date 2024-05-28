using Data.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiliconApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]

    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        var query = _context.Courses
            .Include(i => i.Category)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchQuery))
            query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));

        if (!string.IsNullOrEmpty(category) && category != "all")
            query = query.Where(x => x.Category!.CategoryName == category);

        query = query.OrderByDescending(o => o.Created);

        var totalItemCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        var courses = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        var result = new CourseResult
        {
            TotalItems = totalItemCount,
            TotalPages = totalPages,
            Courses = CourseFactory.Create(courses)
        };

        return Ok(result);
    }

    [HttpGet("{courseId}")]
    public async Task<ActionResult<CourseDetailEntity>> GetCourseDetials(string courseId)
    {
        var courseDetails = await _context.Courses
            .Include(x => x.CourseDetails)
                .ThenInclude(xd => xd.ProgramDetails)
            .FirstOrDefaultAsync(x => x.Id == courseId);

        if (courseDetails == null)
            return NotFound();

        return Ok(courseDetails);
    }



}
