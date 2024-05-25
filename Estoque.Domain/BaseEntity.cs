using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Estoque.Domain
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
    }
}
