using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SpaceBookApi.Models;

namespace SpaceBookApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SubscribedToController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet]
    public async Task<List<SubscribedTo>> GetAllSubscribedTo()
    {
      return await db.SubscribedTos.OrderBy(satellite => satellite.SatelliteId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<SubscribedTo> GetSingleOne(string id)
    {
      return await db.SubscribedTos.FirstOrDefaultAsync(satellite => satellite.SatelliteId == id);
    }

    [HttpPut("{id}")]
    public async Task<SubscribedTo> UpdateSingleOne(int id, string satId, SubscribedTo newData)
    {
      newData.Id = id;
      newData.SatelliteId = satId;
      db.Entry(newData).State = EntityState.Modified;
      await db.SaveChangesAsync();
      return newData;
    }

    [HttpPost]
    public async Task<SubscribedTo> CreateSubscribedTo(SubscribedTo item)
    {
      await db.SubscribedTos.AddAsync(item);
      await db.SaveChangesAsync();
      return item;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSubscribeTo(int id)
    {
      var itemToDelete = db.SubscribedTos.FirstOrDefault(satellite => satellite.Id == id);
      db.SubscribedTos.Remove(itemToDelete);
      db.SaveChanges();
      return Ok();
    }
  }
}