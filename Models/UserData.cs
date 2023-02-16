using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAPI.Models
{
    public class UserData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = null!;

        [BsonElement("name")]
        public string name { get; set; } = null!;

        [BsonElement("country")]
        public string country { get; set; } = null!;

        [BsonElement("annualincome")]
        public double income { get; set; }

        [BsonElement("email")]
        public List<string> email_list { get; set; } = null!;
    }
}
