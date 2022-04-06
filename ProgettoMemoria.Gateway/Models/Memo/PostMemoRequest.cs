using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymGo.Gateway.Models.Memo;

public class PostMemoRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string UserId { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public int DayOfWeek { get; set; }
    public string ExerciseName { get; set; }
    public double Rest { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public DateTime? Expiration { get; set; } = null!;
}
