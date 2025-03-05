using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ManheimWebApi.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("role")]
        [BsonRepresentation(BsonType.String)]
        public Role Role { get; set; }

        [BsonElement("mobile")]
        public long Mobile { get; set; }

        [BsonElement("password")]
        public string Password { get; set; } = null!;


    }

    public enum Role
    {
        TRADER,
        BUYER
    }
}
