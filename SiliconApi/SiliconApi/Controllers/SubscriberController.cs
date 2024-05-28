using Data.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconApi.Attributes;

namespace SiliconApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriberController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetSubscribers()
    {
        return Ok(await _context.Subscribers.ToListAsync());
    }


    [UseApiKey]
    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            var existingSubscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == form.Email);

            if (existingSubscriber == null)
            {
                try
                {
                    _context.Subscribers.Add(SubscriberFactory.Create(form));
                    await _context.SaveChangesAsync();
                    return Created("", null);
                }
                catch
                {
                    return Problem();
                }
            }
            else
            {
                existingSubscriber.DailyNewsletter = form.DailyNewsletter;
                existingSubscriber.AdvertisingUpdates = form.AdvertisingUpdates;
                existingSubscriber.WeekinReview = form.WeekinReview;
                existingSubscriber.EventUpdates = form.EventUpdates;
                existingSubscriber.StartupsWeekly = form.StartupsWeekly;
                existingSubscriber.Podcasts = form.Podcasts;

                _context.Subscribers.Update(existingSubscriber);
                await _context.SaveChangesAsync();

                return Ok();
            }
        }

        return BadRequest();
    }

}



