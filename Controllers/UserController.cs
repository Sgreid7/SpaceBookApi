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
    public List<User> GetAllUsers()
    {
      var users = db.Users.OrderBy(u => u.Name);
      return users.ToList();
    }

    [HttpGet("{id}")]
    public User GetSingleUser(int id)
    {
      var user = db.Users.FirstOrDefault(user => user.Id == id);
      return user;
    }

    [HttpPut("{id}")]

    public User UpdateName(int id)
    {
      var userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);
      return userToUpdate;
    }

    [HttpPost]
    public User CreateUser(User user)
    {
      db.Users.Add(user);
      db.SaveChanges();
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