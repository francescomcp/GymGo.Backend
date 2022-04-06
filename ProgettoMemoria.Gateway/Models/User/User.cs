using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GymGo.Gateway.Models.User;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public DateTime Birthday { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}
