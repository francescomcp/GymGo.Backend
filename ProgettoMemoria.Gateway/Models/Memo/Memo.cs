using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProgettoPromemoria.Gateway.Models.Memo;

public class Memo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public DateTime? Expiration { get; set; } = null!;
}
