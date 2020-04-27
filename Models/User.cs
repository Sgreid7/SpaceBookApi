using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceBookApi.Models
{
  public class User
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    [JsonIgnore]
    public string HashedPassword { get; set; }

    public DateTime Joined { get; set; } = DateTime.Now;

    public string State { get; set; }

    public bool ReceiveNotifications { get; set; }

    public List<SubscribedTo> Satellites { get; set; } = new List<SubscribedTo>();
  }
}