namespace SpaceBookApi.Models
{
  public class SubscribedTo
  {
    public int Id { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }

    public string SatelliteId { get; set; }
  }
}