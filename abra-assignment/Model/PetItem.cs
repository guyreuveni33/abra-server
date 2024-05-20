using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
public class PetItem
{
    [BsonId] // primary key
    [BsonRepresentation(BsonType.ObjectId)] // as the object id isnt a native type in c#, we need to tell the driver how to map it
    public string Id { get; set; }
    public string name { get; set; }
    public string color { get; set; }
    public string type { get; set; }
    public string age { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}