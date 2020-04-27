using System.Text.Json.Serialization;

namespace SpaceBookApi.Models
{
  public class SubscribedTo
  {
    public int Id { get; set; }

    public string SatelliteId { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]

    public User User { get; set; }


  }
}