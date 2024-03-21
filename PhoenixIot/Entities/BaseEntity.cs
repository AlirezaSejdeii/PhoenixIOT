using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoenixIot.Entities;

public abstract class BaseEntity
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}