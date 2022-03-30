using System.Text.Json.Serialization;

namespace ProgettoPromemoria.Gateway.Models.User;

public class PostUserRequest
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
