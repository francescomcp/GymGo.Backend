using MongoDB.Bson.Serialization.Attributes;

namespace ProgettoPromemoria.Gateway.Models.Memo;

public class PostMemoRequest
{
    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public DateTime? Expiration { get; set; } = null!;
}
