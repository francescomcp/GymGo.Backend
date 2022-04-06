using System.Text.Json.Serialization;

namespace GymGo.Gateway.Models.User;

public class PostUserRequest
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public DateTime Birthday { get; set; }
    public string Password { get; set; }
}
