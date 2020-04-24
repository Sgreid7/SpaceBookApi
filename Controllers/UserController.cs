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
  public class UserController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet]
    public async Task<List<User>> GetAllUsers()
    {
      return await db.Users.OrderBy(u => u.Name).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<User> GetSingleUser(int id)
    {
      return await db.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    [HttpPut("{id}")]

    public async Task<User> UpdateUser(int id, string name, string state, string email, bool notifications, User newData)
    {
      newData.Id = id;
      newData.Name = name;
      newData.State = state;
      newData.Email = email;
      newData.ReceiveNotifications = notifications;
      db.Entry(newData).State = EntityState.Modified;
      await db.SaveChangesAsync();
      return newData;
    }

    [HttpPost]
    public async Task<User> CreateUser(User user)
    {
      await db.Users.AddAsync(user);
      await db.SaveChangesAsync();
      return user;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
      var user = db.Users.FirstOrDefault(user => user.Id == id);
      db.Users.Remove(user);
      db.SaveChanges();
      return Ok();
    }
  }
}