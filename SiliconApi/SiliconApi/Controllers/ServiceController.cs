using Data.Contexts;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiliconApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(DataContext context) : ControllerBase
{

    private readonly DataContext _context = context;


    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var services = await _context.Services.OrderBy(o => o.ServiceName).ToListAsync();
        return Ok(ServiceFactory.Create(services));
    }
}
