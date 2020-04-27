using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SpaceBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SpaceBookApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class SubscribedToController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public SubscribedToController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<List<SubscribedTo>> GetAllSubscribedTo()
    {
      return await _context.SubscribedTos.OrderBy(satellite => satellite.SatelliteId).ToListAsync();
    }

    [HttpGet("user/{id}")]
    public async Task<List<SubscribedTo>> GetAllSatellitesForAUser(int userId)
    {
      return await _context.SubscribedTos.OrderBy(satellite => satellite.UserId == userId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<SubscribedTo> GetSingleOne(string id)
    {
      return await _context.SubscribedTos.FirstOrDefaultAsync(satellite => satellite.SatelliteId == id);
    }

    [HttpPut("{id}")]
    public async Task<SubscribedTo> UpdateSingleOne(int id, string satId, SubscribedTo newData)
    {
      newData.Id = id;
      newData.SatelliteId = satId;
      _context.Entry(newData).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return newData;
    }

    [HttpPost("{satelliteId}")]
    public async Task<ActionResult> CreateSubscribedTo(string satelliteId)
    {
      var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "id").Value);
      var subscribedTo = new SubscribedTo
      {
        SatelliteId = satelliteId,
        UserId = userId,
      };

      // add to database
      _context.SubscribedTos.Add(subscribedTo);
      await _context.SaveChangesAsync();
      return Ok(subscribedTo);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubscribeTo(int id)
    {
      var itemToDelete = await _context.SubscribedTos.FirstOrDefaultAsync(satellite => satellite.Id == id);
      _context.SubscribedTos.Remove(itemToDelete);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}